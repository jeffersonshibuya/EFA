(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContatoGrupoRepository', ContatoGrupoRepository);

    ContatoGrupoRepository.$inject = ['$http', 'cache', 'API_URL'];


    function ContatoGrupoRepository($http, cache, API_URL) {

        var service = {
            getGrupos: getGrupos,
            addGrupo: addGrupo,
            deleteGrupo: deleteGrupo,
            saveGrupo: saveGrupo
        };

        return service;

        function getGrupos() {
            var myCache = cache.get('cacheContatoGrupo');
            return $http.get(API_URL+'api/grupos', {cache:myCache});
        }

        function addGrupo(grupo) {
            return $http.post(API_URL+'api/grupos', grupo);
        }

        function deleteGrupo(id) {
            return $http.delete(API_URL+'api/grupos/'+id);
        }

        function saveGrupo(grupo) {
            return $http.put(API_URL+'api/grupos', grupo);
        }
    };


     
})();