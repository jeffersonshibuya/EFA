(function () {
    'use strict';

    angular
        .module('app')
        .controller('editAlunoCtrl', editAlunoCtrl);

    function editAlunoCtrl(AlunoRepository, $scope, $modalInstance, alunoEdit, turmaList, turmaSelected) {
        var vm = this;
        vm.turma = turmaList;
        vm.turma.selected = turmaSelected;

        vm.title = 'Editar Aluno';
        
        $scope.aluno = alunoEdit;

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.save = function (aluno) {
            if (vm.turma.selected != undefined) {
                aluno.TurmaId = vm.turma.selected.TurmaId;
                aluno.Turma = vm.turma.selected;
            } else {
                aluno.TurmaId = null;
                aluno.Turma = null;
            }
                         
            AlunoRepository.saveAluno(aluno).success(function (data) {
                toastr.info(data.Nome + " Foi salvo com sucesso!");
                aluno.Turma = vm.turma.selected;
                $modalInstance.close(aluno);
            }).error(function (error) {
                var errors = [];
                for (var key in error.ModelState) {
                    for (var i = 0; i < error.ModelState[key].length; i++) {
                        errors.push(error.ModelState[key][i]);
                        toastr.error(error.ModelState[key][i]);
                    }
                }
                vm.errors = errors;
            });

        };
        
    }
})();

