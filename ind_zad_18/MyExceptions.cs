using System;
using System.Runtime.Serialization;

namespace ind_zad_18
{
    [Serializable]
    public class MyExceptions : Exception
    {
        public MyExceptions() : base() { }
        // message - хранит сообщение об исключении, текст ошибки

        public MyExceptions(string message) : base(message) { }
        //exception inner - объект класса Exception, хранит информацию об исключении, которое послужило причиной текущего исключения

        public MyExceptions(string message, Exception inner) : base(message, inner) { }

        // определяем конструктор для поддержки сериализации типа
        protected MyExceptions(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
