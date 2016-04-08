(function () {
    'use strict';

    angular.module('app').controller('turmaCtrl', turmaCtrl);

    function turmaCtrl($location, $modal, modalService, TurmaRepository, $scope, ngTableParams, $filter, cache) {

        var vm = this;
        vm.title = 'turmaCtrl';
        vm.turmas = [];
        vm.professores = [];
        vm.alunostTurma = [];

       
        activate();

        function activate() {
            $scope.$emit('LOAD');

            if (!cache.get('cacheTurma')) {
                TurmaRepository.getTurmas().then(function (result) {
                    cache.put('cacheTurma', result.data);
                    vm.turmas = cache.get('cacheTurma');
                    loadTable(vm.turmas);
                }, function(error) {
                    toastr.error(error);
                });
            } else {
                vm.turmas = cache.get('cacheTurma');
                loadTable(vm.turmas);
            }
            $scope.$emit('UNLOAD');
            

        }

        function loadTable(result) {
            var data = result;
            $scope.tableParams = new ngTableParams({
                page: 1,            // show first page
                count: 10,          // count per page
                sorting: {
                    Livro: 'asc'     // initial sorting
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

            $scope.$watch('vm.turmas', function () {
                $scope.tableParams.reload();
            });

            $scope.$watch("search", function () {
                $scope.tableParams.reload();
            });
        }

        function diasSemana(value) {
            var tickedSegunda = false;
            var tickedTerca = false;
            var tickedQuarta = false;
            var tickedQuinta = false;
            var tickedSexta = false;
            var tickedSabado = false;

            if (value.match(/Segunda-feira/)) {
                tickedSegunda = true;
            }
            if (value.match(/Terça-feira/)) {
                tickedTerca = true;
            }
            if (value.match(/Quarta-feira/)) {
                tickedQuarta = true;
            }
            if (value.match(/Quinta-feira/)) {
                tickedQuinta = true;
            }
            if (value.match(/Sexta-feira/)) {
                tickedSexta = true;
            }
            if (value.match(/Sábado/)) {
                tickedSabado = true;
            }

            var diasList = [
            { name: 'Segunda-feira', ticked: tickedSegunda },
            { name: 'Terça-feira', ticked: tickedTerca },
            { name: 'Quarta-feira', ticked: tickedQuarta },
            { name: 'Quinta-feira', ticked: tickedQuinta },
            { name: 'Sexta-feira', ticked: tickedSexta },
            { name: 'Sábado', ticked: tickedSabado }];

            return diasList;
        };

        vm.open = function (size) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/turma/views/createTurma.html',
                size: size,
                resolve: {
                    dias: function () {
                        return diasSemana('');
                    },
                    profList: function () {
                        return TurmaRepository.getProfessores().then(function (result) {
                            return result.data;
                        });
                    },
                    alunosList: function () {
                        return TurmaRepository.getAlunos().then(function (result) {
                            return result.data;
                        });
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/turma/controllers/createTurmaCtrl.js']);
                        }
                    ]
                },
                controller: 'createTurmaCtrl as vm'

            });
            vm.modalInstance.result.then(function (data) {
                vm.turmas.push(data);
                $scope.tableParams.reload();
                toastr.success("Turma: " + data.Livro + " cadastrada");
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                vm.modalInstance = undefined;
            });
        };

        vm.openAlunos = function (turmaId) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/turma/views/alunosTurma.html',
                //size: size,
                resolve: {
                    alunosTurma: function () {
                        return TurmaRepository.getAlunosTurma(turmaId).then(function (result) {
                            return result.data;
                        }, function (error) {
                            console.log(error);
                        });
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/turma/controllers/alunosTurmaCtrl.js', 'js/Repositories/AlunoRepository.js']);
                        }
                    ]
                },
                controller: 'alunosTurmaCtrl as vm'

            });
            vm.modalInstance.result.then(function (data) {
                //vm.turmas.unshift(data);
                //toastr.success("Turma: " + data.Livro + "cadastrada");
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                vm.modalInstance = undefined;
            });
        };

        vm.openEdit = function (size, turma) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/turma/views/editTurma.html',
                size: size,
                controller: 'editTurmaCtrl as vm',
                resolve: {
                    turma: function () {
                        return turma;
                    },
                    profSelected: function () {
                        return turma.Professor;
                    },
                    dias: function () {
                        return diasSemana(turma.Dias);
                    },
                    profList: function () {
                        return TurmaRepository.getProfessores().then(function (result) {
                            return result.data;
                        });
                    },
                    alunosList: function () {
                        return TurmaRepository.getAlunos().then(function (result) {
                            return result.data;
                        });
                    },
                    alunosTurma: function () {
                        return TurmaRepository.getAlunosTurma(turma.TurmaId).then(function (result) {
                            return result.data;
                        });
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/turma/controllers/editTurmaCtrl.js', 'js/Repositories/AlunoRepository.js']);
                        }
                    ]
                }
            });
            vm.modalInstance.result.then(function (data) {
                toastr.success("Turma atualizada com sucesso!");
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                vm.modalInstance = undefined;
            });
        };

        vm.delete = function (turma) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Excluir',
                headerText: 'Excluir ' + turma.Livro + '?',
                bodyText: 'Atenção: Todos os alunos desta turma serão desvinculados, deseja continuuar?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                var turmaId = turma.TurmaId;
                TurmaRepository.deleteTurma(turmaId).then(function () {
                    toastr.success("Turma excluída com Sucesso!");
                    cache.remove('cacheAlunos');
                    $.each(vm.turmas, function (i) {
                        if (vm.turmas[i].TurmaId === turmaId) {
                            vm.turmas.splice(i, 1);
                            return false;
                        }
                    });
                    $scope.tableParams.reload();
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir aluno!");
                };
            });
        };
    }
})();
