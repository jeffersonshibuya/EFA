(function () {
    'use strict';

    angular.module('app').controller('usuarioCtrl', usuarioCtrl);

    function usuarioCtrl(UsuarioRepository, $modal, modalService, $location, $scope, ngTableParams, $filter, $cacheFactory, cache) {
        var vm = this;
        vm.title = "Lista de Usuários";
        vm.usuarios = [];          

        //Loadings
        $scope.loadingCreate = false;        

        activate();

        function activate() {
            $scope.$emit('LOAD');
            
            if ($scope.authentication.isAdmin) {
                if (!cache.get('cacheUsuarios')) {
                    UsuarioRepository.getUsuarios().then(function (result) {
                        cache.put('cacheUsuarios', result.data);
                        vm.usuarios = cache.get('cacheUsuarios');
                    }, function (error) {
                        vm.usuarios = undefined;
                        toastr.error(error);
                        console.log(error);
                    });
                } else {
                    vm.usuarios = cache.get('cacheUsuarios');
                }
            }
           
            $scope.$emit('UNLOAD');
        }

        vm.addRole = function(Id, Role) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Confirmar',
                headerText: 'Adicionar Permissão de '+Role+' ?',
                bodyText: 'Tem certeza que deseja que este usuário tenha privilégios de  '+Role+' ?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                UsuarioRepository.addRole(Id, Role).then(function () {
                    toastr.success("Permissão concedida com Sucesso!");
                    cache.remove('cacheUsuarios');
                    $location.path('/app/usuarios');
                }), function (data) {
                    toastr.error(data.message, "Erro ao adicionar permissão ao usuário!");
                };
            });
        };

        vm.removeRole = function (Id, Role) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Remover',
                headerText: 'Remover Permissão de ' + Role + ' ?',
                bodyText: 'Tem certeza que deseja cancelar a permissão de: '+Role+' para este usuário ?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                UsuarioRepository.removeRole(Id, Role).then(function () {
                    toastr.success("Permissão cancelada com Sucesso!");
                    cache.remove('cacheUsuarios');
                    $location.path('/app/usuarios');
                }), function (data) {
                    toastr.error(data.message, "Erro ao remover permissão ao usuário!");
                };
            });
        };

        vm.open = function (size) {
            $scope.loadingCreate = true;
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/accounts/views/createUsuario.html',
                size: size,
                resolve: {
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/accounts/controllers/createUsuarioCtrl.js']);
                        }
                    ]
                },
                controller: 'createUsuarioCtrl as vm',
            });
            vm.modalInstance.result.then(function (data) {
                vm.usuarios.unshift(data);
                cache.remove('cacheDash');
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                $scope.loadingCreate = false;
                vm.modalInstance = undefined;
            });
        };


        vm.openEdit = function (size, usuario) {
            vm.modalInstance = $modal.open({
                templateUrl: 'js/app/accounts/views/editUsuario.html',
                size: size,
                controller: 'editUsuarioCtrl as vm',
                resolve: {
                    usuarioEdit: function () {
                        return usuario;
                    },
                    deps: [
                        '$ocLazyLoad',
                        function ($ocLazyLoad) {
                            return $ocLazyLoad.load(['js/app/accounts/controllers/editUsuarioCtrl.js']);
                        }
                    ]
                }
            });
            vm.modalInstance.result.then(function () {
            }, function () {
                console.log('Cancelled');
            })['finally'](function () {
                vm.modalInstance = undefined;
            });
        };


        vm.delete = function (usuario) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Excluir',
                headerText: 'Excluir ' + usuario.FullName + '?',
                bodyText: 'Tem certeza que deseja exlcuir este usuário?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                UsuarioRepository.deleteUsuario(usuario.Id).then(function () {
                    toastr.success("Usuário excluído com Sucesso!");
                    $.each(vm.usuarios, function (i) {
                        if (vm.usuarios[i].Id === usuario.Id) {
                            vm.usuarios.splice(i, 1);
                            return false;
                        }
                    });
                    $location.path('/app/usuarios');
                }), function (data) {
                    toastr.error(data.message, "Erro ao excluir usuário!");
                };
            });
        };

        vm.resetPassword = function (usuario) {
            var modalOptions = {
                closeButtonText: 'Cancelar',
                actionButtonText: 'Resetar',
                headerText: 'Resetar Senha ?',
                bodyText: 'A nova senha para este usuário será: 123456, Confirmar Execução?',
            };

            modalService.showModal({}, modalOptions).then(function () {
                UsuarioRepository.resetPassword(usuario.Id).then(function () {
                    toastr.success("Senha resetada com Sucesso!");                   
                    $location.path('/app/usuarios');
                }), function (data) {
                    toastr.error(data.message, "Erro ao resetar senha!");
                };
            });
        };
    }
})();
