(function () {
    'use strict';

    angular
        .module('app')
        .factory('TurmaRepository', TurmaRepository);

    TurmaRepository.$inject = ['$http', 'cache', 'API_URL'];


    function TurmaRepository($http, cache, API_URL) {

        var service = {
            getTurmas: getTurmas,
            getById: getById,
            listTurmas: listTurmas,
            addTurma: addTurma,
            addAlunoTurma: addAlunoTurma,
            deleteTurma: deleteTurma,
            saveTurma: saveTurma,
            getProfessores: getProfessores,
            getAlunos: getAlunos,
            getAlunosTurma: getAlunosTurma,
        };

        return service;

        //Retorna todas as Turmas Include Professores
        function getTurmas() {
            var myCache = cache.get('cacheTurma');
            return $http.get(API_URL+'api/getturma', {cache:myCache});
        }

        function listTurmas() {
            return $http.get(API_URL+'api/getturma');
        }

        function getById(id) {
            return $http.get(API_URL+'api/turma/'+id);
        }

        function getProfessores() {
            return $http.get(API_URL + 'api/turma/professores');
        }

        function getAlunos() {
            return $http.get(API_URL + 'api/turma/alunos');
        }

        function getAlunosTurma(turmaId) {
            return $http.get(API_URL + 'api/turma/alunosTurma/' + turmaId);
        }

        function addTurma(turma) {
            return $http.post(API_URL + 'api/turma', turma);
        }

        function addAlunoTurma(alunoTurma) {
            return $http.post(API_URL + 'api/turma/addAlunoTurma', alunoTurma);
        };

        function deleteTurma(id) {
            return $http.delete(API_URL + 'api/turma/' + id);
        }

        function saveTurma(turma) {
            return $http.put(API_URL + 'api/turma', turma);
        }
    };



})();