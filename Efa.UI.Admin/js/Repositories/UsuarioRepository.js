(function () {
    'use strict';

    angular
        .module('app')
        .factory('UsuarioRepository', UsuarioRepository);

    UsuarioRepository.$inject = ['$http', 'cache', 'API_URL'];


    function UsuarioRepository($http, cache, API_URL) {

        var service = {
            getUsuarios: getUsuarios,
            addUsuario: addUsuario,
            editUsuario: editUsuario,
            resetPassword: resetPassword,
            deleteUsuario: deleteUsuario,
            addRole: addRole,
            removeRole: removeRole,
            alterarSenha: alterarSenha
        };

        return service;

        function getUsuarios() {
            var myCache = cache.get('cacheUsuarios');
            return $http.get(API_URL + 'api/accounts/users', { cache: myCache });
        }

        function addUsuario(usuario) {            
            return $http.post(API_URL + 'api/accounts/create', usuario);
        }

        function editUsuario(usuario) {
            return $http.post(API_URL + 'api/accounts/edit', usuario);
        }

        function resetPassword(id) {
            return $http.post(API_URL + 'api/accounts/resetPassword/' + id);
        }

        function deleteUsuario(id) {
            return $http.delete(API_URL + 'api/accounts/user/' + id);
        }

        function addRole(id, role) {
            return $http.put(API_URL + 'api/accounts/user/addRole/' + id + '/' + role);
        }

        function removeRole(id, role) {
            return $http.put(API_URL + 'api/accounts/user/removeRole/' + id + '/' + role);
        }

        function alterarSenha(usuario) {
            return $http.post(API_URL + 'api/accounts/ChangePassword', usuario);
        }


    };


     
})();