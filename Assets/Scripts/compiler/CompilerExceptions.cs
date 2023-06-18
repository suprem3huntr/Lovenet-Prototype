using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CompilerExceptions {

    class GameException: Exception {
        protected string message;
        
        public GameException(string message) {
            this.message = message;
        }

        public override string Message {
            get {
                return this.message;
            }
        }

    }

    class SyntaxException : GameException {
        public SyntaxException(string message) : base(message) {
        }
    }

    class RuntimeException : GameException {
        public RuntimeException(string message) : base(message) {
        }
    }

}
