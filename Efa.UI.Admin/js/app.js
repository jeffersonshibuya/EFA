'use strict';


angular.module('app', [
    'ngAnimate',
    'ngRoute',
    'ngCookies',
    'ngResource',
    'ngSanitize',
    'ngTouch',
    'ngStorage',
    'ui.router',
    'ui.bootstrap',
    'ui.load',
    'ui.jq',
    'ui.validate',
    'ui.keypress',
    'oc.lazyLoad',
    'isteven-multi-select',
    'angular-spinkit',
    'ngTable',
    'angular-ladda'
])
.constant('API_URL', 'http://192.168.1.100:4525/');

//'pascalprecht.translate',