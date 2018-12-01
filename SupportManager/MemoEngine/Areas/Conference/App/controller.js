
(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$scope'];

    function controller($scope) {
        $scope.title = 'TechDays 2016 개발자 컨퍼런스';

        activate();

        function activate() { }
    }


    // TechDays 2016 관련 리스트/상세보기 컨트롤러
    //var techdays = angular.module('app').controller('techdays', []);
    //[a] 모듈 참조(네임스페이스)
    var techdays = angular.module('app');

    //[b] 리스트 컨트롤러
    techdays.controller('ListController', ['$scope', '$http', function ($scope, $http) {
        //[1] JSON 파일 사용: 이것을 사용하기 위해서는 Web.config 파일의 <system.webServer>에 <staticContent><mimeMap fileExtension=".json" mimeType="application/json"/></staticContent> 항목 설정 필요
        //$http.get('/App/data/speakers.json').success(function (data) {
        //    $scope.speakers = data;
        //});
        //[2] 제네릭 핸들러 사용
        //$http.get('Handlers/SpeakerHandler.ashx').success(function (data) {
        //    $scope.speakers = data;
        //});
        //[3] Web API 사용
        $http.get('/api/Speakers').success(function (data) {
            $scope.speakers = data;
        });
    }]);

    //[c] 상세보기 컨트롤러
    techdays.controller('DetailsController', ['$scope', '$http', '$routeParams',
        function ($scope, $http, $routeParams) {


        //$http.get('Handlers/SpeakerHandler.ashx').success(function (data) {
        $http.get('/api/Speakers').success(function (data) {

            $scope.speakers = data;

            /// 모듈에서 #/SpeakerDetails/:Id 식으로 정의됨
            // 리스트에서 상세보기로 #/SpeakerDetails/1 식으로 전달
            $scope.currentId = $routeParams.Id; 

            if ($routeParams.Id > 0) {
                $scope.prevId = Number($routeParams.Id) - 1;
            } else {
                $scope.prevId = $scope.speakers.length - 1; // 마지막
            }

            if ($routeParams.Id < $scope.speakers.length - 1) {
                $scope.nextId = Number($routeParams.Id) + 1;
            } else {
                $scope.nextId = 0; // 처음
            }
        });
    }]);



})();
