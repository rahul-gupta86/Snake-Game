using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGamePro.Core
{
    public class GameStorage<T>
    {
        public T Data { get; set; }

        public GameStorage(T data)
        {
            Data = data;
        }
    }
}
