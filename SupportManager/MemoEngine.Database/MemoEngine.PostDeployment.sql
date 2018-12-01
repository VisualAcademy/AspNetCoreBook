﻿/*
배포 후 스크립트 템플릿							
--------------------------------------------------------------------------------------
 이 파일에는 빌드 스크립트에 추가될 SQL 문이 있습니다.		
 SQLCMD 구문을 사용하여 파일을 배포 후 스크립트에 포함합니다.			
 예:      :r .\myfile.sql								
 SQLCMD 구문을 사용하여 배포 후 스크립트의 변수를 참조합니다.		
 예:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\install\Divisions.PostDeployment.sql	
:r .\install\Domains.PostDeployment.sql	
:r .\install\UserProfiles.PostDeployment.sql
:r .\install\Membership.PostDeployment.sql

