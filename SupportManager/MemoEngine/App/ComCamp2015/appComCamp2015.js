(function () {
    'use strict';

    var appComCamp2015 = angular.module('appComCamp2015', [
        // Angular modules 
        'ngAnimate',
        'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        
    ]);


    // 라우트 설정
    appComCamp2015.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.

            when('/SpeakerList', {
                templateUrl: '/Templates/SpeakerList.html',
                controller: 'ListController'
            }).

            when('/SpeakerDetails/:Id', {
                templateUrl: '/Templates/SpeakerDetails.html',
                controller: 'DetailsController'
            }).

            otherwise({
                redirectTo: '/SpeakerList'
            });

    }]);


})();