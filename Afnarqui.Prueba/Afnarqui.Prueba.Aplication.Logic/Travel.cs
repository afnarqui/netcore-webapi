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
            List<int> valuesChangesCopia = new List<int>();
            List<int> valuesChangesCopiaPosicion = new List<int>();
            List<int> valuesTemp = new List<int>();
            List<int> valuesTempReal = new List<int>();
            List<int> valuesReturn = new List<int>();
            var valuesReturncadena = "";
            var listvaluesReturncadena = new List<KeyValuePair<int, int>>();
            var recorrerValores = new List<devolver>();
            var recorrerValoresCopia = new List<devolver>();

            //var list = new List<KeyValuePair<string, int>>() {
            //    new KeyValuePair<string, int>("A", 1)};



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
                    valuesTemp.Clear();
                    valuesTempReal.Clear();
                    valuesChanges.Clear();

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
                            cuantos = cuantos + 1;
                            var day = i + 1;
                          
                            recorrerValores.Add(new devolver { dia = day, value = 1 });

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

                            if (result >= 50)
                            {
                                if (result > 100)
                                {
                                    var menoraaUltaaaa = 0;
                                    var mayoraaUltaaaa = 0;
                                    var contadoraaUltaaaa = 0;
                                    var countaaaa = valuesChanges.Count;
                                    valuesChangesCopia.Clear();
                                    valuesChangesCopiaPosicion.Clear();
                                    for (int k = 0; k < valuesChanges.Count; k++)
                                    {
                                        valuesChangesCopia.Add(valuesChanges[k]);
                                    }
                                    if (i == 4)
                                    {
                                        var afn = "";
                                    }
                                    for (int aaaa = 0; aaaa < countaaaa; aaaa++)
                                    {
                                        if (valuesChangesCopia[aaaa] >= 50 && valuesChangesCopia[aaaa] <= 100)
                                        {
                                            var day = i + 1;
                                                                                                 
                                            recorrerValores.Add(new devolver { dia = day, value = 1 });
                                            ultimo = ultimo - 1;
                                        }
                                    }
                                    for (int k = 0; k < valuesChangesCopiaPosicion.Count; k++)
                                    {
                                        valuesChanges.RemoveAt(valuesChangesCopiaPosicion[k]);
                                    }

                                }
                                else
                                {
                                    valuesTempReal.Add(valuesChanges[0]);
                                    valuesTempReal.Add(valuesChanges[ultimo]);
                                    cuantos = cuantos + 1;
                                    var day = i + 1;
                                                                                       
                                    recorrerValores.Add(new devolver { dia = day, value = 1 });

                                    valuesChanges.RemoveAt(ultimo);
                                    valuesChanges.RemoveAt(0);
                                    ultimo = ultimo - valuesTempReal.Count;
                                }
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

                                        if (queHago == false)
                                        {
                                            valuesReturn.Add(valuesTemp[valuesTemp.Count - 1]);
                                            valuesTemp.RemoveAt(valuesTemp.Count - 1);
                                            queHago = true;
                                        }
                                        else
                                        {
                                            valuesReturn.Add(valuesTemp[0]);
                                            valuesTemp.RemoveAt(0);
                                            queHago = false;
                                        }

                                        var contadoraa = 0;
                                        var menoraa = 0;
                                        var mayoraa = 0;
                                        int aa = 0;
                                        int recoaa = valuesReturn.Count;
                                        for (aa = 0; aa < recoaa; aa++)
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
                                                else
                                                {
                                                    result = 0;
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
                                                    
                                            recorrerValores.Add(new devolver { dia = day, value = 1 });


                                            ultimo = ultimo - contadoraa;
                                        }
                                        else
                                        {
                                            var ultimoUltimo = 0;
                                            ultimoUltimo = valuesReturn.Count;

                                            var sumarUltimo = 0;
                                            var cuantosUltimo = 0;
                                            var resultUltimo = 0;
                                            while (ultimoUltimo > 0 && aa == valuesReturn.Count + valuesTemp.Count)
                                            {
                                                var contadoraaUlt = 0;
                                                var menoraaUlt = 0;
                                                var mayoraaUlt = 0;
                                                for (int aaa = 0; aaa < valuesReturn.Count; aaa++)
                                                {
                                                    if (valuesReturn[aaa] > mayoraaUlt)
                                                    {
                                                        menoraaUlt = mayoraaUlt;
                                                        mayoraaUlt = valuesReturn[aaa];

                                                    }
                                                    else
                                                    {
                                                        menoraaUlt = valuesReturn[aaa];
                                                    }
                                                    contadoraaUlt = contadoraaUlt + 1;
                                                    if (aaa == valuesReturn.Count - 1)
                                                    {
                                                        if (mayoraaUlt * contadoraaUlt <= 50)
                                                        {
                                                            result = mayoraaUlt * contadoraaUlt;
                                                            var day = i + 1;
                                                            recorrerValores.Add(new devolver { dia = day, value = 1 });
                                                            valuesReturn.Clear();
                                                            aaa = valuesReturn.Count + 1;
                                                        }
                                                        else
                                                        {
                                                            result = 0;
                                                        }
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


     

            for (int i = 0; i < recorrerValores.Count; i++)
            {
                var dia = recorrerValores[i].dia;
                var vals = recorrerValores[i].value;
                if (i == 0)
                {
                    recorrerValoresCopia.Add(new devolver { dia = dia, value = 1 });
                }
                else
                {
                    var contador = 0;
                    for (int k = 0; k < recorrerValoresCopia.Count; k++)
                    {
                        var diaCopia = recorrerValoresCopia[k].dia;
                        if(diaCopia == dia)
                        {
                            recorrerValoresCopia[k].value+= 1;
                            contador = 1;
                        }
                        if (k == recorrerValoresCopia.Count - 1 && contador == 0) {
                            recorrerValoresCopia.Add(new devolver { dia = dia, value = 1 });
                            k = recorrerValoresCopia.Count + 1;
                        }
                        
                    }
                }
            }

            valuesReturncadena = "";
            for (int i = 0; i < recorrerValoresCopia.Count; i++)
            {
                valuesReturncadena+= "Case #" + recorrerValoresCopia[i].dia.ToString() + ": " + recorrerValoresCopia[i].value.ToString() + ";";
            }




            return valuesReturncadena;

        }

    }

    public class devolver
    {
        public int dia { get; set; }
        public int value { get; set; }
    }
}

