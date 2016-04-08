(function () {
    'use strict';

    angular
        .module('app')
        .factory('ContatoPessoaRepository', ContatoPessoaRepository);

    ContatoPessoaRepository.$inject = ['$http', 'API_URL'];


    function ContatoPessoaRepository($http, API_URL) {

        var service = {
            getContatos: getContatos,
            addContato: addContato,
            deleteContato: deleteContato,
            saveContato: saveContato
        };

        return service;

        function getContatos() {
            return $http.get(API_URL+'api/contatos');
        }

        function addContato(contato) {
            return $http.post(API_URL+'api/contatos', contato);
        }

        function deleteContato(id) {
            return $http.delete(API_URL+'api/contatos/'+id);
        }

        function saveContato(contato) {
            return $http.put(API_URL+'api/contatos', contato);
        }
    };


     
})();