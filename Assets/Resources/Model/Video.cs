public class Video{

    public int day;
    public long views;
    public long today_views;
    public double quality;
    public long target_views;
    public long timestamp_seconds;


    public Video(){}

    public Video (int day, long views, long today_views, double quality, long target_views, long timestamp_seconds){
        this.day = day;
        this.views = views;
        this.today_views = today_views;
        this.quality = quality;
        this.target_views = target_views;
        this.timestamp_seconds = timestamp_seconds;

    }
}
