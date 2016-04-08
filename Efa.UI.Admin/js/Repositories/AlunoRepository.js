(function () {
    'use strict';

    angular
        .module('app')
        .factory('AlunoRepository', AlunoRepository);

    AlunoRepository.$inject = ['$http', 'cache', 'API_URL'];


    function AlunoRepository($http, cache, API_URL) {

        var service = {
            getAlunos: getAlunos,
            addAluno: addAluno,
            deleteAluno: deleteAluno,
            saveAluno: saveAluno,
            invalidateCache: invalidateCache
        };

        return service;

        function getAlunos() {
            var myCache = cache.get('cacheAlunos');
            return $http.get(API_URL+'api/alunos', {cache:myCache});
        }

        function addAluno(aluno) {            
            return $http.post(API_URL+'api/alunos', aluno);
        }

        function deleteAluno(id) {
            return $http.delete(API_URL+'api/alunos/'+id);
        }

        function saveAluno(aluno) {
            return $http.put(API_URL+'api/alunos', aluno);
        }

        function invalidateCache() {            
            return $http.get(API_URL+'api/alunos/teste');
        }
    };


     
})();