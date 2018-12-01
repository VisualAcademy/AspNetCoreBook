(function () {
    'use strict';

    angular
        .module('photoGallery')
        .controller('photoGalleryController', photoGalleryController);

    photoGalleryController.$inject = ['$scope']; 

    function photoGalleryController($scope) {
        $scope.title = '포토 갤러리';


        var vm = this;

        vm.photos = [
            { "id": 1, "name": "홍길동1", "title": "진달래1", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 2, "name": "홍길동2", "title": "진달래2", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 3, "name": "홍길동3", "title": "진달래3", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 4, "name": "홍길동4", "title": "진달래4", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 5, "name": "홍길동5", "title": "진달래5", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 6, "name": "홍길동6", "title": "진달래6", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 7, "name": "홍길동7", "title": "진달래7", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" },
            { "id": 8, "name": "홍길동8", "title": "진달래8", "content": "진달래 사진", "fileName": "http://placehold.it/400x300" }
        ];

        activate();

        function activate() { }
    }

})();
