(function () {
    'use strict';

    angular.module('app').controller('professorCtrl', professorCtrl);

    function professorCtrl(ProfessorRepository, $modal, modalService, $location, $scope, cache) {
        var vm = this;
        vm.title = "Lista dos Professores";
        vm.professores = [];

        //Loadings
        $scope.loadingCreate = false;

        activate();

        function activate() {
            $scope.$emit('LOAD');

            if (!cache.get('cacheProfessores')) {
                ProfessorRepository.getProfessores().then(function (result) {
                    cache.put('cacheProfessores', result.data);
                    vm.professores = cache.get('cacheProfessores');
                }, function (error) {
                    console.log(error);
                    toastr.error(error);
                });
            } else {
                vm.professores = cache.get('cacheProfessores');
            }
            $scope.$emit('UNLOAD');
        }


        vm.open = function (size) {
            $scope.loadingCreate = true;
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/professores/views/createProfessor.html',
                size: size,
                resolve: {
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/professores/controllers/createProfessorCtrl.js']);
                        }
                    ]
                },
                controller: 'createProfessorCtrl as vm',
            });
            vm.modalInstance.result.then(function (data) {
                vm.professores.unshift(data);
                cache.remove('cacheDash');
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                $scope.loadingCreate = false;
                vm.modalInstance = undefined;
            });
        };


        vm.openEdit = function (size, professor) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/professores/views/editProfessor.html',
                size: size,
                controller: 'editProfessorCtrl as vm',
                resolve: {
                    professorEdit: function () {
                        return professor;
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/professores/controllers/editProfessorCtrl.js']);
                        }
                    ]
                }
            });
            vm.modalInstance.result.then(function () {
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                // unset modalInstance to prevent double close of modal when $routeChangeStart
                vm.modalInstance = undefined;
            });
        };

        vm.delete = function (professor) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Excluir',
                headerText: 'Excluir ' + professor.Nome + '?',
                bodyText: 'Tem certeza que deseja exlcuir este professor?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                var professorId = professor.ProfessorId;
                ProfessorRepository.deleteProfessor(professorId).then(function () {
                    cache.remove('cacheDash');
                    toastr.success("Professor excluído com Sucesso!");
                    $.each(vm.professores, function (i) {
                        if (vm.professores[i].ProfessorId === professorId) {
                            vm.professores.splice(i, 1);
                            return false;
                        }
                    });
                    $location.path('/app/professores');
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir professor!");
                };
            });
        };
    }
})();
