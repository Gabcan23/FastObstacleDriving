using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] songs;
    [SerializeField] private float trackTimer;
    [SerializeField] private float songPlayed;
    [SerializeField] private bool[] beenPlayed;

    private static MusicManager instance;

    public static MusicManager Instance{
        get{
            return instance;
        }
    }

    private void Awake(){
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(instance);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        beenPlayed = new bool[songs.Length];

        if(! _audioSource.isPlaying){
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_audioSource.isPlaying){
            trackTimer+= 1 * Time.deltaTime;
        }

        if(! _audioSource.isPlaying || trackTimer>= _audioSource.clip.length){
            ChangeSong(Random.Range(0, songs.Length));
        }

        if(songPlayed==songs.Length){
            songPlayed=0;
            for(int i=0; i<songs.Length; i++){
                if(i==songs.Length){
                    break;
                }
                else{
                    beenPlayed[i]=false;
                }
            }
        }

        ResetShuffle();
    }

    public void ChangeSong(int songPicked){

        if(!beenPlayed[songPicked]){
            trackTimer = 0;
            songPlayed++;
            beenPlayed[songPicked]=true;
            _audioSource.clip = songs[songPicked];
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }

    private void ResetShuffle(){
        if(songPlayed==songs.Length){
            songPlayed=0;
            for(int i=0; i<songs.Length; i++){
                if(i==songs.Length){
                    break;
                }
                else{
                    beenPlayed[i]=false;
                }
            }
        }
    }
}
