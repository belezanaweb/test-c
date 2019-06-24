using System;
using System.Collections.Generic;
using System.Linq;

namespace BelezanaWeb.Model
{
    /// <summary>
    /// Esta classe representa o resultado padrão para métodos.
    /// </summary>
    public class ResultBase
    {
        /// <summary>
        /// Inicializa o objeto
        /// </summary>
        public ResultBase()
        {

        }

        /// <summary>
        /// Indica se o resultado do processamento do método é de Sucesso(True) ou de falha (False)
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensagem que será exibida para o solicitante (api, tela, etc).
        /// </summary>
        public string FriendlyMessage { get; set; }

        /// <summary>
        /// Mensagem de erro/sucesso que será gravado no log.
        /// </summary>
        public string MessageLog { get; set; }

        /// <summary>
        /// Objeto que contém imformações detalhadas sobre o erro.
        /// </summary>
        public Exception Error { get; set; }

        /// <summary>
        /// Contém a string de solicitação.
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Contém string de retorno.
        /// </summary>
        public string Response { get; set; }
    }

    /// <summary>
    /// Esta classe representa o resultado padrão para métodos
    /// </summary>
    public class Result<T> : ResultBase
    {
        public Result()
        {
            Objects = new List<T>();
        }

        /// <summary>
        /// Lista de objetos do tipo declarado.
        /// </summary>
        public List<T> Objects { get; set; }

        /// <summary>
        /// Primeiro item da lista Objects. 
        /// </summary>
        public T Object
        {
            get
            {
                if (Objects == null || Objects.Count == 0)
                    return default(T);

                return Objects.FirstOrDefault();
            }
        }

        /// <summary>
        /// As propriedades da superclass.
        /// </summary>
        public ResultBase ResultBase
        {
            get
            {
                var result = new ResultBase();

                result.FriendlyMessage = this.FriendlyMessage;
                result.MessageLog = this.MessageLog;
                result.Request = this.Request;
                result.Response = this.Response;
                result.Success = this.Success;               

                return result;
            }

            set { }
        }
    }
}
