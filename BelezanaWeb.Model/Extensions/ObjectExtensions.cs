using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BelezanaWeb.Model.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Cria uma cópia indentica do objeto e o aloca em um novo endereço de memória.
        /// O objeto que será clonado deve ser 'Serializable'.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Clone<T>(this T source) where T : class
        {
            using (Stream cloneStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(cloneStream, source);
                cloneStream.Position = 0;
                T clone = (T)formatter.Deserialize(cloneStream);
                return clone;
            }
        }
    }
}
