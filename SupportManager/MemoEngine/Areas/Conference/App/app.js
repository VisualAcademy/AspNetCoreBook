
(function () {
    'use strict';

    //[!] 모듈 생성: 'app' 이름으로 모듈 생성
    var app = angular.module('app', [
        // Angular modules 
        'ngRoute'

        // Custom modules 


        // 3rd Party Modules

    ]);

    //[!] Angular 라우트 설정
    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.

            when('/SpeakerList', {
                templateUrl: '/Areas/Conference/Templates/SpeakerList.html',
                controller: 'ListController'
            }).

            when('/SpeakerDetails/:Id', {
                templateUrl: '/Areas/Conference/Templates/SpeakerDetails.html',
                controller: 'DetailsController'
            }).

            otherwise({
                redirectTo: '/SpeakerList'
            });

    }]);



})();
