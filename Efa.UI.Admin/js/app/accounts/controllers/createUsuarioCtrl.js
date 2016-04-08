/// <reference path="createUsuarioCtrl.js" />
(function () {
    'use strict';

    angular
        .module('app')
        .controller('createUsuarioCtrl', createUsuarioCtrl);

    function createUsuarioCtrl(UsuarioRepository, $scope, $modalInstance) {
        var vm = this;

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };


        vm.cadastrar = function (usuario) {
            UsuarioRepository.addUsuario(usuario).success(function (data) {
                toastr.success(data.Name+" Foi cadastrado com sucesso!");
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
