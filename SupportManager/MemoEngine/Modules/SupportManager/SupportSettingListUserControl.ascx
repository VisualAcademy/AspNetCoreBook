<%@ Control Language="C#" AutoEventWireup="true" 
    CodeBehind="SupportSettingListUserControl.ascx.cs" 
    Inherits="MemoEngine.Modules.SupportManager.SupportSettingListUserControl" %>

<div ng-app="supportSettingApp">
    <div data-ng-controller="supportSettingController" class="container">
        <h2>{{ title }}</h2>
        <h3>{{ subTitle }}</h3>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <table class="table table-bordered table-hover"
                            style="width:100%;">
                        <tr>
                            <th>&nbsp;</th>
                            <th>번호</th>
                            <td>게시판</td>
                            <th>게시판번호</th>
                            <th>이벤트 등록 시작일</th>
                            <th>최대 등록자</th>
                            <th>상세보기</th>
                        </tr>
                        <tr data-ng-repeat="setting in settings">
                            <td style="text-align:center;">
                                <span ng-if="setting.isClosed">종료됨</span>
                                <span ng-if="!setting.isClosed">진행중</span>
                            </td>
                            <td>
                                {{ setting.id }}
                            </td>
                            <td>
                                {{ setting.boardName }}
                            </td>
                            <td>
                                {{ setting.boardNum }}
                            </td>
                            <td>
                                {{ setting.eventDate }}
                            </td>
                            <td>
                                {{ setting.maxCount }}
                            </td>
                            <td>
                                <a href="./SupportSettingView.aspx?BoardName={{setting.boardName}}&Num={{setting.boardNum}}"
                                    class="btn btn-primary">
                                    설정 상세보기
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="divFullScreen" data-ng-show="loading">
            <img src="/images/ajaxIndicator.gif" class="ajaxIndicator" />
        </div>
    </div>
</div>

<script src="/Scripts/angular.js"></script>

<script>
    (function () {
        'use strict';

        //[1] Angualr 모듈 선언
        var supportSettingApp = angular.module('supportSettingApp', []);

        //[2][1] Angualr 컨트롤러 선언
        supportSettingApp.controller('supportSettingController'
            , ['$scope', '$http', supportSettingController]);

        //[2][2] 컨트롤러 구현부
        function supportSettingController($scope, $http) {
            // 웹 서비스 경로 
            var API_URL = "/api/SupportSettingService/";

            // 속성(Property)
            $scope.title = "서포트 설정 관리";
            $scope.subTitle = "서포트 설정 리스트";
            $scope.loading = true; // 로딩 창 띄우기

            // 출력: GET
            $http.get(API_URL).success(function (data) {
                $scope.settings = data;
                $scope.loading = false;
            })
            .error(function () {
                $scope.error = "데이터를 가져오는 동안 에러가 발생했습니다. ";
                $scope.loading = false;
            });
        } 
    })();
</script>
