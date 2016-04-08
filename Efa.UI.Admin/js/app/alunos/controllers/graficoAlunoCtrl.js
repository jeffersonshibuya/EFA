(function () {
    'use strict';

    angular
        .module('app')
        .controller('graficoAlunoCtrl', graficoAlunoCtrl);

    function graficoAlunoCtrl($scope, alunoService, $location) {
        var vm = this;
        
        vm.aluno = alunoService.getAluno();
        
        if (vm.aluno.NotasId != null) {

            if (vm.aluno.Turma.TipoProva == 'Default' || vm.aluno.Turma.TipoProva == undefined) {
                $scope.totalQuiz = 25;
                $scope.totalWritten = 50;
                $scope.written = [[1, vm.aluno.Notas.WrittenTest1], [2, vm.aluno.Notas.WrittenTest2]];
                $scope.writtenTicks = [[1, 'Written Test 1'], [2, 'Written Test 2']];
                $scope.max = 3;
            } else {
                $scope.totalQuiz = 50;
                $scope.totalWritten = 100;
                $scope.written = [[1, vm.aluno.Notas.WrittenTest1], [2, vm.aluno.Notas.WrittenTest2], [3, vm.aluno.Notas.WrittenTest3], [4, vm.aluno.Notas.WrittenTest4]];
                $scope.writtenTicks = [[1, 'Cap. 1 e 2'], [2, 'Cap. 3 e 4'], [3, 'Cap. 5 e 6'], [4, 'Cap. 7 e 8']];
                $scope.max = 5;
            }

            $scope.quiz = [[1, vm.aluno.Notas.Quiz1], [2, vm.aluno.Notas.Quiz2], [3, vm.aluno.Notas.Quiz3], [4, vm.aluno.Notas.Quiz4], [5, vm.aluno.Notas.Quiz5], [6, vm.aluno.Notas.Quiz6], [7, vm.aluno.Notas.Quiz7], [8, vm.aluno.Notas.Quiz8]];

            $scope.oral = [[1, vm.aluno.Notas.OralTest1], [2, vm.aluno.Notas.OralTest2]];

            $scope.avaliacaoProfessor = [[1, vm.aluno.Notas.RealizacaoTarefas], [2, vm.aluno.Notas.ComportamentoDisciplina], [3, vm.aluno.Notas.Desenvolvimento], [4, vm.aluno.Notas.ResponsabilidadeInteresse], [5, vm.aluno.Notas.Compreensao], [6, vm.aluno.Notas.Assiduidade], [7, vm.aluno.Notas.Gramatica], [8, vm.aluno.Notas.Vocabulario]];
        } else {
            toastr.warning('Selecione um aluno');
            $location.path('app/alunos');
        }
    }

})();

