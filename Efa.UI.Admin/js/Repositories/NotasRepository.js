(function () {
    'use strict';

    angular
        .module('app')
        .factory('NotasRepository', NotasRepository);

    NotasRepository.$inject = ['$http', 'API_URL'];


    function NotasRepository($http, API_URL) {

        var service = {
            getAlunoNotas: getAlunoNotas,
            addNotas: addNotas,
            deleteNotas: deleteNotas,
            savenotas : saveNotas
        };

        return service;

        function getAlunoNotas(notasId) {
            return $http.get(API_URL+'api/notas/aluno/'+notasId);
        }

        function addNotas(alunoId, notas) {            
            return $http.post(API_URL+'api/notas/'+alunoId, notas);
        }

        function deleteNotas(id, alunoId) {
            return $http.delete(API_URL+'api/notas/'+id+'/'+alunoId);
        }

        function saveNotas(notas) {
            return $http.put(API_URL+'api/notas', notas);
        }
    };


     
})();