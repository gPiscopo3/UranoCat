public class Video{

    public int day;
    public long views;
    public long today_views;
    public double quality;
    
    public long timestamp_seconds;


    public Video(){}

    public Video (int day, long views, long today_views, double quality, long timestamp_seconds){
        this.day = day;
        this.views = views;
        this.today_views = today_views;
        this.quality = quality;
        
        this.timestamp_seconds = timestamp_seconds;

    }
}
