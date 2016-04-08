(function () {
    'use strict';

    angular.module('app').controller('alunoCtrl', alunoCtrl);

    function alunoCtrl(AlunoRepository, TurmaRepository, $modal, modalService, $location, $scope, ngTableParams, $filter, alunoService, $cacheFactory, cache) {
        var vm = this;
        vm.title = "Lista de Alunos";
        vm.alunos = [];

        //Busca dados na cache com ID 'cacheAlunos'
        //var cache = $cacheFactory.get('cacheAlunos');                

        //Loadings
        $scope.loadingCreate = false;

        //Selection Alunos
        $scope.selection = [];
        $scope.toggleSelection = function toggleSelection(aluno) {
            var idx = $scope.selection.indexOf(aluno);

            // is currently selected
            if (idx > -1) {
                $scope.selection.splice(idx, 1);
            }

                // is newly selected
            else {
                $scope.selection.push(aluno);
            }
        };

        activate();

        function activate() {
            $scope.$emit('LOAD');

            //Se não econtrar cache com esse ID, cria um novo cache com ID 'cacheAlunos' com valores dos alunos'.
            //Senão, encontrou o cache e só lista os valores do mesmo.
            if (!cache.get('cacheAlunos')) {
                AlunoRepository.getAlunos().then(function (result) {
                    cache.put('cacheAlunos', result.data);
                    vm.alunos = cache.get('cacheAlunos');
                }, function (error) {
                    vm.alunos = undefined;
                    toastr.error(error);
                })['finally'](function () {
                    loadTable(vm.alunos);
                });
            } else {
                vm.alunos = cache.get('cacheAlunos');
                loadTable(vm.alunos);
            }

            $scope.$emit('UNLOAD');
        }

        $scope.invalidateCache = function () {
            cache.remove('cacheDash');
        };

        function loadTable(result) {
            var data = result;
            $scope.tableParams = new ngTableParams({
                page: 1,            // show first page
                count: 5,          // count per page
                sorting: {
                    Nome: 'asc'     // initial sorting
                },
            }, {
                counts: [5, 10, 20],
                total: data.length, // length of data
                getData: function ($defer, params) {
                    // use build-in angular filter
                    var filteredData = params.filter() ?
                            $filter('filter')(data, $scope.search) :
                            data;
                    var orderedData = params.sorting() ?
                            $filter('orderBy')(filteredData, params.orderBy()) :
                            data;

                    params.total(orderedData.length); // set total for recalc pagination
                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });

            $scope.$watch('vm.alunos', function () {
                $scope.tableParams.reload();
            });

            $scope.$watch("search", function () {
                $scope.tableParams.reload();
            });
        }

        vm.gerarBoletim = function () {
            if ($scope.selection.length != 0) {
                alunoService.addAlunos($scope.selection);
                $location.path("/app/boletim");
            } else {
                toastr.error('Nenhum aluno foi selecionado');
            }
        };

        vm.alunoNotas = function (aluno) {
            //$cookieStore.put('aluno', aluno);
            alunoService.setAluno(aluno);
            $location.path("/app/notas");
        };

        vm.open = function (size) {
            $scope.loadingCreate = true;
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/alunos/views/createAluno.html',
                size: size,
                resolve: {
                    turmaList: function () {
                        return TurmaRepository.listTurmas().then(function (result) {
                            return result.data;
                        });
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/alunos/controllers/createAlunoCtrl.js']);
                        }
                    ]
                },
                controller: 'createAlunoCtrl as vm'
            });
            vm.modalInstance.result.then(function (data, turma) {
                cache.remove('cacheDash');
                vm.alunos.push(data);
                $scope.tableParams.reload();                
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                $scope.loadingCreate = false;
                vm.modalInstance = undefined;
            });
        };

        vm.openEdit = function (size, aluno) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/alunos/views/editAluno.html',
                size: size,
                controller: 'editAlunoCtrl as vm',
                resolve: {
                    alunoEdit: function () {
                        return aluno;
                    },
                    turmaList: function () {
                        return TurmaRepository.listTurmas().then(function (result) {
                            return result.data;
                        });
                    },
                    turmaSelected: function () {
                        return aluno.Turma;
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/alunos/controllers/editAlunoCtrl.js']);
                        }
                    ]
                }
            });
            vm.modalInstance.result.then(function (data) {
                $scope.tableParams.reload();
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                vm.modalInstance = undefined;
            });
        };

        vm.delete = function (aluno) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Excluir',
                headerText: 'Excluir ' + aluno.Nome + '?',
                bodyText: 'Tem certeza que deseja exlcuir este aluno?',
                //templateUrl: 'app/areas/aluno/views/create.html'
            };

            modalService.showModal({}, modalOptions).then(function () {
                var alunoId = aluno.AlunoId;
                AlunoRepository.deleteAluno(alunoId).then(function () {
                    cache.remove('cacheDash');
                    toastr.success("Aluno excluído com Sucesso!");
                    $.each(vm.alunos, function (i) {
                        if (vm.alunos[i].AlunoId === alunoId) {
                            vm.alunos.splice(i, 1);
                            return false;
                        }
                    });
                    $scope.tableParams.reload();
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir aluno!");
                };
            });
        };

        vm.graficoAluno = function (aluno) {
            alunoService.setAluno(aluno);
            $location.path('/app/grafico');
        };
    }
})();
