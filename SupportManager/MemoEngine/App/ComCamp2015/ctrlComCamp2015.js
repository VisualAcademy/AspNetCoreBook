(function () {
    'use strict';

    angular
        .module('appComCamp2015')
        .controller('ctrlComCamp2015', ctrlComCamp2015);

    ctrlComCamp2015.$inject = ['$scope'];

    function ctrlComCamp2015($scope) {
        $scope.title = 'MVP COM CAMP 2015';

        activate();

        function activate() { }
    }


    //[a] 모듈 참조(네임스페이스)
    var techdays = angular.module('appComCamp2015');

    //[b] 리스트 컨트롤러
    techdays.controller('ListController', ['$scope', '$http', function ($scope, $http) {
        $http.get('/App/ComCamp2015/data/speakers.json').success(function (data) {
            $scope.speakers = data;
        });
    }]);

    //[c] 상세보기 컨트롤러
    techdays.controller('DetailsController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
        $http.get('/Handlers/SpeakerHandler.ashx').success(function (data) {
            $scope.speakers = data;
            $scope.currentId = $routeParams.Id;

            if ($routeParams.Id > 0) {
                $scope.prevId = Number($routeParams.Id) - 1;
            } else {
                $scope.prevId = $scope.speakers.length - 1;
            }

            if ($routeParams.Id < $scope.speakers.length - 1) {
                $scope.nextId = Number($routeParams.Id) + 1;
            } else {
                $scope.nextId = 0;
            }
        });
    }]);


})();
