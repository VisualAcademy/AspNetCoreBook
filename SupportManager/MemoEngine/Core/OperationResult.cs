using System;
using System.Collections.Generic;

namespace MemoEngine.Core
{
    /// <summary>
    /// 다중 값을 반환하는 형태를 ref/out 매개변수 대신, Tuple of T 대신에 OperationResult 형태로 반환
    /// 다중 값을 담아서 반환 가능
    /// </summary>
    public class OperationResult
    {
        public bool Success { get; set; }

        public List<String> MessageList { get; private set; }

        public OperationResult()
        {
            MessageList = new List<String>();
            Success = true;
        }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
    }
}