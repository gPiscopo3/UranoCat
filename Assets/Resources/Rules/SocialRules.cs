using System.Collections.Generic;

public class SocialRules{


    //k -> giorni
    //t -> secondi
    //V(k) = a * F(k) * q(k);
    //q(k) -> comb lineare statischiche gatto
    //v(t) = V(k)(1-e^-t/T)
    //T -> tempo di raggiungimento massime visualizzazioni
    //F(k+1) = F(k) + v(k) * b * N(k)
    //N(k) = TOT - F(k) 


    public double a_factor; //numero di visualizzazioni medie per utente
    public double b_factor; //percentuali di nuovi utenti
    public double Max_Followers;
    public double Start_Followers;
    public double TAU; //tempo di assestamento views

    public List<QualityRule> quality_rules;

    public class QualityRule{

        public CatTag stat;
        public double factor;
    }

    public SocialRules(){}


}