using System.Collections.Generic;

public class SocialRules{


    //k -> giorni
    //t -> secondi
    //V(k) = a * F(k) * Q(k);
    //Q(K) = [q(k)/q_soglia]^n;    0 <= Q(k) <= 1

    //q(k) -> comb lineare statischiche gatto
    //F(K+1) = F(K) + b * V(K) * QF(k)
    //QF(k) = [(q(k) - qmin)/(qmax - qmin)]^m; 0 <= QF(k) <= 1



    public double views_factor; //a
    public double views_quality_power_factor; //n
    public double followers_factor;  //b
    public double followers_quality_power_factor;  //b
    
    public List<QualityRule> quality_rules;
    public List<FollowersRule> followers_rules;

    public class QualityRule{

        public CatTag stat;
        public double factor;

        public QualityRule(){}
    }

    public class FollowersRule{

        public long followers;
        public double min_quality_followers;
        public double max_quality_followers;
        public double rif_quality_views;

        public FollowersRule(){}

        public override string ToString()
        {
            return followers + " " + min_quality_followers + " " + max_quality_followers + " " + rif_quality_views;
        }
    }

    public SocialRules(){}


}