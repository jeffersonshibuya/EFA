(function () {
    'use strict';

    angular
        .module('app')
        .controller('createTurmaCtrl', createTurmaCtrl);

    //createAlunoCtrl.$inject = ['AlunoRepository', '$scope', '$modalInstance'];

    function createTurmaCtrl(TurmaRepository, $scope, $modalInstance, profList, dias, alunosList, cache) {
        var vm = this;
        vm.title = 'Turma';
        vm.professores = profList;
        $scope.dias = dias;
        var turma = {};
        var alunoTurma = {};

        $scope.items = [
         { id: 1, name: 'Padrão', value: 'Default' },
         { id: 2, name: 'Connection', value: 'Connection' }
        ];

        $scope.selectedItem = $scope.items[0];


        vm.alunos = alunosList;

        $scope.alunos = [];

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.cadastrar = function (turmaForm) {
            //angular.forEach($scope.alunos.select, function (value, key) {
            //    //alert(value.Nome);
            //});

            var diasSemana = '';

            angular.forEach($scope.diasSelect, function (value, key) {
                diasSemana = diasSemana + value.name + ' / ';
                //if ($scope.diasSelect.length - 1 == key) {
                //    diasSemana = diasSemana + value.name + '.';
                //} else {
                //    diasSemana = diasSemana + value.name + ',';
                //}
            });

            turma.Dias = diasSemana;
            turma.Livro = turmaForm.Livro;
            turma.HorarioInicio = turmaForm.HorarioInicio;
            turma.HorarioFim = turmaForm.HorarioFim;
            alunoTurma.Alunos = $scope.alunos.select;
            turma.TipoProva = $scope.selectedItem.value;
            turma.ProfessorId = turmaForm.ProfessorId;

            TurmaRepository.addTurma(turma).success(function (data) {
                //toastr.success(" Turma cadastrada com sucesso!");
                alunoTurma.TurmaId = data.TurmaId;
                cache.remove('cacheTurma');
                TurmaRepository.addAlunoTurma(alunoTurma).then(function () {
                    cache.remove('cacheAlunos');
                    //toastr.success(" Alunos vinculados com sucesso!");
                }, function() {
                    toastr.success(" Um erro ocorreu ao tentar vincular os alunos!");
                });
                window.location.reload();
                $modalInstance.close(data);
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
