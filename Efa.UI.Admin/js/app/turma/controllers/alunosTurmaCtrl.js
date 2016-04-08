(function () {
    'use strict';

    angular.module('app').controller('alunosTurmaCtrl', alunosTurmaCtrl);

    function alunosTurmaCtrl($modalInstance, modalService, TurmaRepository, AlunoRepository, $scope, alunosTurma, alunoService, $location) {
       
        var vm = this;
        vm.title = 'alunosTurma';
        vm.alunosTurma = alunosTurma;
       
        $scope.checkAll = function () {
            if ($scope.selectedAll) {
                $scope.selectedAll = true;
                angular.forEach(vm.alunosTurma, function (item) {
                    if (item.NotasId != null) {
                        $scope.selection.push(item);
                        item.Selected = $scope.selectedAll;
                    }
                });
            } else {
                $scope.selectedAll = false;
                angular.forEach(vm.alunosTurma, function (item) {
                    if (item.NotasId != null) {
                        var idx = $scope.selection.indexOf(item);
                        if (idx > -1) {
                            $scope.selection.splice(idx, 1);
                        }
                        item.Selected = $scope.selectedAll;
                    }
                });
            }
            

        };

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

        vm.cancel = function() {
            $modalInstance.dismiss('cancel');
        };

        vm.gerarBoletim = function () {
            if ($scope.selection.length != 0) {
                alunoService.addAlunos($scope.selection);
                $modalInstance.dismiss('cancel');
                $location.path("/app/boletim");
            } else {
                toastr.error('Nenhum aluno foi selecionado');
            }
        };

        vm.desvincularAluno = function(aluno) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Confirmar',
                headerText: 'Desvincular Aluno ?',
                bodyText: 'Deseja desvincular este aluno da turma?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                aluno.TurmaId = null;
                AlunoRepository.saveAluno(aluno).then(function() {
                    toastr.success("Aluno Desvinculado!");
                    cache.remove('cacheAlunos');
                    $.each(vm.alunosTurma, function(i) {
                        if (vm.alunosTurma[i].AlunoId === aluno.AlunoId) {
                            vm.alunosTurma.splice(i, 1);
                            return false;
                        }
                    });
                }), function(data) {
                    toastr.error(data.message, "Erro ao excluir aluno!");
                };
            });
        };

        vm.alunoNotas = function (aluno) {
            alunoService.setAluno(aluno);
            $modalInstance.dismiss('cancel');
            $location.path("/app/notas");
        };
    }
})();
