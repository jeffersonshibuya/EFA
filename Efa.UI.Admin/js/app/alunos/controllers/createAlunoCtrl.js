(function () {
    'use strict';

    angular
        .module('app')
        .controller('createAlunoCtrl', createAlunoCtrl);

    //createAlunoCtrl.$inject = ['AlunoRepository', '$scope', '$modalInstance'];

    function createAlunoCtrl(AlunoRepository, TurmaRepository, $scope, $modalInstance, turmaList, cache) {
        var vm = this;
        vm.title = 'createAlunoCtrl';
        vm.turma = turmaList;
        vm.t = {};


        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.cadastrar = function (aluno) {
            if (vm.turma.selected != undefined) 
                aluno.TurmaId = vm.turma.selected.TurmaId; 
            AlunoRepository.addAluno(aluno).success(function (data) {
                toastr.success(data.Nome + " Foi cadastrado com sucesso!");
                if (data.TurmaId != null) {
                    TurmaRepository.getById(data.TurmaId).success(function(turma) {
                        data.Turma = turma;
                    });
                }
                $modalInstance.close(data, vm.t);
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
