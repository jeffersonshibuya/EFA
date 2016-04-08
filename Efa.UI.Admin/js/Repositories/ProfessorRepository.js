(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProfessorRepository', ProfessorRepository);

    ProfessorRepository.$inject = ['$http', 'cache', 'API_URL'];


    function ProfessorRepository($http, cache, API_URL) {

        var service = {
            getProfessores: getProfessores,
            addProfessor: addProfessor,
            deleteProfessor: deleteProfessor,
            saveProfessor: saveProfessor
        };

        return service;

        function getProfessores() {
            var myCache = cache.get('cacheProfessores');
            return $http.get(API_URL+'api/professores', {cache:myCache});
        };

        function addProfessor(professor) {
            return $http.post(API_URL+'api/professores', professor);
        }

        function deleteProfessor(id) {
            return $http.delete(API_URL+'api/professor/'+id);
        }

        function saveProfessor(professor) {
            return $http.put(API_URL+'api/professores', professor);
        }
    };


     
})();