using System;
using System.Collections.Generic;
using System.Linq;

namespace Afnarqui.Prueba.Aplication.Logic
{
    public class Travel
    {

        public string search(string cadena)
        {
            string values = cadena;

            string[] data = values.Split(',');
            List<int> valuesNew = new List<int>();
            List<int> valuesChanges = new List<int>();
            List<int> valuesTemp = new List<int>();
            List<int> valuesTempReal = new List<int>();
            List<int> valuesReturn = new List<int>();
            var valuesReturncadena = "";
            foreach (string item in data)
            {
                if (item.Trim() != "")
                {
                    valuesNew.Add(Int32.Parse(item));

                }
            }


            int count = 0;
            try
            {
                count = valuesNew[0];
                valuesNew.RemoveAt(0);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }


            for (int i = 0; i < count; i++)
            {
                try
                {
                    int firts = valuesNew[0];
                    valuesNew.RemoveAt(0);

                    for (int k = 0; k < firts; k++)
                    {
                        valuesChanges.Add(valuesNew[0]);
                        valuesNew.RemoveAt(0);

                    }
                    valuesChanges.Sort();
                    var ultimo = valuesChanges.Count - 1;

                    var sumar = 0;
                    var cuantos = 0;
                    while (ultimo > 0)
                    {
                        int firtMa = valuesChanges[0];
                        if (firtMa >= 50 && firtMa <= 100)
                        {
                            valuesTempReal.Add(valuesChanges[0]);
                            valuesTempReal.Add(valuesChanges[ultimo]);
                            cuantos = cuantos + 1;
                            var day = i + 1;

                            valuesReturncadena += "Case #" + day.ToString() + ": " + cuantos.ToString() + '\n';

                            valuesChanges.RemoveAt(ultimo);
                            valuesChanges.RemoveAt(0);
                            ultimo = ultimo - 1;

                        }
                        else
                        {
                            int result = 0;
                            if (sumar == 0)
                            {
                                int firt = valuesChanges[0];
                                int ult = valuesChanges[ultimo];

                                if (firt > ult)
                                {
                                    result = firt * 2;
                                }
                                else
                                {
                                    result = ult * 2;
                                }
                            }

                            if (result >= 50 && result <= 100)
                            {
                                valuesTempReal.Add(valuesChanges[0]);
                                valuesTempReal.Add(valuesChanges[ultimo]);
                                cuantos = cuantos + 1;
                                var day = i + 1;

                                valuesReturncadena += "Case #" + day.ToString() + ": " + cuantos.ToString() + '\n';

                                valuesChanges.RemoveAt(ultimo);
                                valuesChanges.RemoveAt(0);
                                ultimo = ultimo - valuesTempReal.Count;
                            }
                            else
                            {
                                if (sumar > 0)
                                {
                                    valuesTemp.Add(valuesChanges[0]);
                                    valuesChanges.RemoveAt(0);

                                }
                                else
                                {
                                    valuesTemp.Add(valuesChanges[0]);
                                    valuesTemp.Add(valuesChanges[ultimo]);
                                    valuesChanges.RemoveAt(ultimo);
                                    valuesChanges.RemoveAt(0);

                                }
                                ultimo = ultimo - 1;
                                sumar += 1;
                                cuantos = 0;
                                if (ultimo <= 0)
                                {
                                    valuesTemp.Sort();
                                    var ciclo = valuesTemp.Count;
                                    var queHago = false;
                                    for (int j = 0; j < ciclo; j++)
                                    {
                                        //var por = valuesTemp.Count;
                                        //int firtOld = valuesTemp[0];
                                        //int ultOld = valuesTemp[valuesTemp.Count - 1];

                                        if (j % 2 == 0 && valuesTemp.Count > 1)
                                        {
                                            valuesReturn.Add(valuesTemp[0]);
                                            valuesReturn.Add(valuesTemp[valuesTemp.Count - 1]);
                                            valuesTemp.RemoveAt(0);
                                            valuesTemp.RemoveAt(valuesTemp.Count - 1);
                                        }
                                        else
                                        {
                                            if(queHago == true)
                                            {
                                                valuesReturn.Add(valuesTemp[valuesTemp.Count - 1]);
                                                valuesTemp.RemoveAt(valuesTemp.Count - 1);
                                                queHago = false;
                                            }
                                            else
                                            {
                                                valuesReturn.Add(valuesTemp[0]);
                                                valuesTemp.RemoveAt(0);
                                                queHago = true;
                                            }
                                            
                                            
                                        }



                                        var contadoraa = 0;
                                        var menoraa = 0;
                                        var mayoraa = 0;
                                        for (int aa = 0; aa < valuesReturn.Count; aa++)
                                        {
                                            if (valuesReturn[aa] > mayoraa)
                                            {
                                                menoraa = mayoraa;
                                                mayoraa = valuesReturn[aa];

                                            }
                                            else
                                            {
                                                menoraa = valuesReturn[aa];
                                            }
                                            contadoraa = contadoraa + 1;
                                            if (aa == valuesReturn.Count - 1)
                                            {
                                                if (mayoraa * contadoraa >= 50 && mayoraa * contadoraa <= 100)
                                                {
                                                    result = mayoraa * contadoraa;
                                                    valuesReturn.Clear();
                                                }
                                            }

                                        }


                                      
                                        if (result >= 50 && result <= 100)
                                        {
                                          
                                            cuantos = cuantos + 1;
                                            var day = i + 1;
                                            if (valuesTemp.Count == 0)
                                            {
                                                j = ciclo + 1;
                                            }
                                            valuesReturncadena += "Case #" + day.ToString() + ":1";
                                            
                                      
                                            ultimo = ultimo - contadoraa;
                                        }
                                        else
                                        {
                                            var ultimoUltimo = valuesChanges.Count;

                                            var sumarUltimo = 0;
                                            var cuantosUltimo = 0;
                                            var resultUltimo = 0;
                                            while (ultimoUltimo > 0)
                                            {
                                                var porUltimo = valuesTemp.Count;
                                                var porUltimoReal = porUltimo + 1;
                                                var reporUltimoReal = valuesTemp.FindIndex(x => x == valuesTemp[0]);

                                                int firtOldUltimo = valuesTemp[0];
                                                int ultOldUltimo = valuesTemp[porUltimo - 1];
                                                int valorNuevo = valuesChanges[0];
                                                if (valorNuevo > firtOldUltimo && valorNuevo > ultOldUltimo)
                                                {
                                                    resultUltimo = valorNuevo * porUltimoReal;
                                                }
                                                else
                                                {
                                                    if (firtOldUltimo > ultOldUltimo)
                                                    {
                                                        resultUltimo = firtOldUltimo * porUltimoReal;
                                                    }
                                                    else
                                                    {
                                                        resultUltimo = ultOldUltimo * porUltimoReal;
                                                    }

                                                }
                                                if (resultUltimo >= 50 && resultUltimo <= 100)
                                                {

                                                    cuantosUltimo = cuantosUltimo + 1;
                                                    var day = i + 1;
                                                    if (sumarUltimo == 0)
                                                    {
                                                        valuesTemp.RemoveAt(0);
                                                    }
                                                    else
                                                    {
                                                        for (int zz = 0; zz < sumarUltimo; zz++)
                                                        {
                                                            if (zz % 2 == 0)
                                                            {
                                                                valuesTemp.RemoveAt(0);
                                                            }
                                                            else
                                                            {
                                                                var dig = valuesTemp.Count - 1;
                                                                valuesTemp.RemoveAt(dig);
                                                            }

                                                        }

                                                    }
                                                    valuesReturncadena += "Case #" + day.ToString() + ": " + sumarUltimo.ToString() + "\n";
                                                    ultimoUltimo = ultimoUltimo - sumarUltimo;
                                                    valuesChanges.RemoveAt(0);
                                                    if (valuesChanges.Count == 0 && ultimoUltimo == 0)
                                                    {
                                                        valuesTemp.Clear();
                                                    }
                                                }
                                                sumarUltimo = sumarUltimo + 1;
                                            }
                                        }


                                    }
                                }
                            }
                        }



                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            return valuesReturncadena;

        }

    }
}
