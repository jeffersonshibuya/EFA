(function () {
    'use strict';

    angular
        .module('app')
        .controller('editUsuarioCtrl', editUsuarioCtrl);

    function editUsuarioCtrl(UsuarioRepository, $scope, $modalInstance, usuarioEdit) {
        var vm = this;

        vm.title = 'Editar Usuário';
        
        $scope.usuario = usuarioEdit;

        vm.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        vm.save = function (usuario) {
            usuario.Name = usuario.FullName;
            UsuarioRepository.editUsuario(usuario).success(function (data) {
                toastr.info(data.Name + " Foi salvo com sucesso!");
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

