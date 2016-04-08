(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('editTurmaCtrl', editTurmaCtrl);

    //createAlunoCtrl.$inject = ['AlunoRepository', '$scope', '$modalInstance'];

    function editTurmaCtrl(TurmaRepository, $scope, $modalInstance, modalService, AlunoRepository, profList, dias, alunosList, turma, alunosTurma, profSelected, cache) {
        var vm = this;
        vm.title = 'Turma';
        vm.professores = profList;
        $scope.dias = dias;
        $scope.turma = turma;
        $scope.turma.Professor = profSelected;
        var alunoTurma = {};
        vm.alunosTurma = alunosTurma;

        vm.alunos = alunosList;

        $scope.alunos = [];

        $scope.items = [
         { id: 1, name: 'Padrão', value: 'Default' },
         { id: 2, name: 'Connection', value: 'Connection' }
        ];

        if (turma.TipoProva == 'Default') {
            $scope.selectedItem = $scope.items[0];
        } else {
            $scope.selectedItem = $scope.items[1];
        }
            

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };


        vm.desvincularAluno = function (aluno) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Desvincular',
                headerText: 'Desvinculoar Aluno ?',
                bodyText: 'Deseja desvincular este aluno da turma?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                aluno.TurmaId = null;
                aluno.Turma = null;
                AlunoRepository.saveAluno(aluno).then(function () {
                    toastr.success("Aluno Desvinculado!");
                    cache.remove('cacheAlunos');
                    $.each(vm.alunosTurma, function (i) {
                        if (vm.alunosTurma[i].AlunoId === aluno.AlunoId) {
                            vm.alunosTurma.splice(i, 1);
                            return false;
                        }
                    });
                    vm.alunos.push(aluno);
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir aluno!");
                };
            });
        };

        vm.cadastrar = function (turmaForm, selectedItem) {
            //angular.forEach($scope.alunos.select, function (value, key) {
            //    //alert(value.Nome);
            //});

            var diasSemana = '';

            angular.forEach($scope.diasSelect, function (value, key) {
                diasSemana = diasSemana + value.name + ' / ';
            });            
            turma.Dias = diasSemana;
            turma.Livro = turmaForm.Livro;
            turma.TipoProva = $scope.selectedItem.value;
            turma.HorarioInicio = turmaForm.HorarioInicio;
            turma.HorarioFim = turmaForm.HorarioFim;
            alunoTurma.Alunos = $scope.alunos.select;
            if (turmaForm.Professor != undefined) {
                turma.Professor = turmaForm.Professor;
                turma.ProfessorId = turmaForm.Professor.ProfessorId;
            }            

            TurmaRepository.saveTurma(turma).success(function (data) {
                alunoTurma.TurmaId = data.TurmaId;
                TurmaRepository.addAlunoTurma(alunoTurma).then(function () {
                    cache.remove('cacheAlunos');
                }, function() {
                    toastr.success(" Um erro ocorreu ao tentar vincular os alunos!");
                });
                $modalInstance.close(turma);
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
