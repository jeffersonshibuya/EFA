(function () {
    'use strict';

    angular.module('app').service('alunoService', alunoService);

    //alunoService.$inject = ['$http'];

    function alunoService() {
        var alunosList = [];
        var thisAluno = {};

        var setAluno = function (aluno) {
            thisAluno = aluno;
        };

        var getAluno = function() {
            return thisAluno;
        };

        var addAlunos = function (listAlunos) {
            alunosList = listAlunos;
        };

        var getAlunosList = function() {
            return alunosList;
        };

        return {
            addAlunos: addAlunos,
            getAlunosList: getAlunosList,

            setAluno: setAluno,
            getAluno: getAluno,
        };
    }
})();