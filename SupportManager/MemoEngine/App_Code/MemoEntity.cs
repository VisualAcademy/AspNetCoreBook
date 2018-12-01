using System;

public class MemoEntity
{
    #region Num : 번호
    private int _Num;
    /// <summary>
    /// Num : 번호
    /// </summary>
    public int Num
    {
        get { return _Num; }
        set { _Num = value; }
    }
    #endregion

    #region Name : 작성자
    private string _Name;
    /// <summary>
    /// Name : 작성자
    /// </summary>
    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    #endregion

    #region Email : 이메일
    private string _Email;
    /// <summary>
    /// Email : 이메일
    /// </summary>
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    #endregion

    #region Title : 메모(150자 이내)
    private string _Title;
    /// <summary>
    /// Title : 메모(150자 이내)
    /// </summary>
    public string Title
    {
        get { return _Title; }
        set { _Title = value; }
    }
    #endregion

    #region PostDate : 작성일
    private DateTime _PostDate;
    /// <summary>
    /// PostDate : 작성일
    /// </summary>
    public DateTime PostDate
    {
        get { return _PostDate; }
        set { _PostDate = value; }
    }
    #endregion

    #region PostIP : IP주소
    private string _PostIP;
    /// <summary>
    /// PostIP : IP주소
    /// </summary>
    public string PostIP
    {
        get { return _PostIP; }
        set { _PostIP = value; }
    }
    #endregion
}