Create Procedure UpdateTerm
(
    @Id Int,
    @Title NVarChar(20),
    @Description NVarChar(100)
)
As
	Begin Tran -- 트랜잭션(한 단위로 묶어서 처리)

		Update Terms 
		Set
			Title = @Title,
			Description = @Description
		Where Id = @Id

		If @@Error > 0
			Rollback Tran -- 취소(복구)

	Commit Tran -- 실행
Go
