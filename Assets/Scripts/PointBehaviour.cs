using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBehaviour : MonoBehaviour
{
    static Dictionary<PointVoiceGroup, string[]> voices = new Dictionary<PointVoiceGroup, string[]>()
                {
					{ PointVoiceGroup.Normal, new string[] {"Nice one!", "Gotta tell someone!", "Wow :O", "OMG!", "I can’t believe it!", "NO WAY", "Mom MUST see this!", "Dad MUST see this!", "Dude!", "wut?" }},
					{ PointVoiceGroup.Skeptical, new string[] {"Hm...", "Could it be...?", "It could be true..."}},
					{ PointVoiceGroup.Believer, new string[] {"FOLLOW ME!", "REPOST!", "REPOSTING!", "THIS IS IMPORTANT", "THIS IS RELEVANT"}},
					{ PointVoiceGroup.Press, new string[] {"It'll be my cover!!", "Front page material!", "Such a scoop!", "Stop the presses!", "Breaking News!", "Extra! Extra!"}},
					{ PointVoiceGroup.Multiple, new string[] {"Wow :O", "OMG!", "I can’t believe it!", "NO WAY", "Gotta tell the guys!", "People should know this!", "Posting on family group!"}}
                };

    public bool activated = false;
    public enum PointTypes { Point, Goal, SubGoal };
    public PointTypes Type;
	public enum PointVoiceGroup { Normal, Skeptical, Believer, Press, Multiple };
    public PointVoiceGroup Voice;
	AudioController audioController;
    public Sprite activeSprite;

    public bool ChainReaction = false;

    [SerializeField]
    private int _Ammo = 3;
    [SerializeField]
    private float _Range = 3;

    public int Ammo
    {
        get { return _Ammo; }
        set
        {
            _Ammo = value;
            if (ammoLabel) ammoLabel.text = Ammo.ToString();
            if (_Ammo == 0)
            {
                deactivate();
                ammoLabel.text = "";
            }
        }
    }

    public float Range
    {
        get { return _Range; }
        set { _Range = value; }
    }

    private Text ammoLabel;

    // Use this for initialization
    void Start()
    {
		audioController = GameObject.FindObjectOfType<AudioController> ();
        ammoLabel = GetComponentInChildren<Text>();
        Ammo = _Ammo;

        if (activated)
            activate();
    }


    public void activate()
    {
        ///check if shields
        ShieldHPBehaviour shields = gameObject.GetComponent<ShieldHPBehaviour>();

        if (shields && shields.activeShields > 0)
        {
            //Debug.Log ("i have shields!");
            shields.disableShield();
            if (audioController) audioController.playShieldHit();
            return;
        }

        activated = true;

        if (Type == PointTypes.Goal)
        {
            if (audioController) audioController.playGoal();
        }
        else if (Type == PointTypes.Point)
        {
            if (audioController) audioController.playScore();
        }
        else if (Type == PointTypes.SubGoal)
        {
            if (audioController) audioController.playStar();
        }


        if (ammoLabel) ammoLabel.color = Color.white;

        if (gameObject.GetComponent<Launcher>()) gameObject.GetComponent<Launcher>().enabled = true;
        if (gameObject.GetComponent<RangeBehaviour>()) gameObject.GetComponent<RangeBehaviour>().enabled = true;
        if (gameObject.GetComponent<ShieldBehaviour>()) gameObject.GetComponent<ShieldBehaviour>().enabled = false;
        if (gameObject.GetComponent<ShieldHPBehaviour>()) gameObject.GetComponent<ShieldHPBehaviour>().enabled = false;

        var thisVoices = voices[Voice];
        if (gameObject.GetComponent<PopupBehaviour>()) gameObject.GetComponent<PopupBehaviour>().Play(thisVoices[Random.Range(0, thisVoices.Length)]);

        GameObject baseObject = this.gameObject.transform.Find ("Base").gameObject;
		baseObject.GetComponent<SpriteRenderer> ().sprite = activeSprite;

        gameObject.transform.Find("Base").GetComponent<Collider2D>().enabled = false;

        if (ChainReaction)
            StartCoroutine(AutoFire(0.01f));
    }

    IEnumerator AutoFire(float time)
    {
        yield return new WaitForSeconds(time);

        Ammo -= 1;
        gameObject.GetComponent<Launcher>().launch();
    }

    public void deactivate()
    {
        activated = false;
        
        gameObject.GetComponent<Launcher>().enabled = false;
        gameObject.GetComponent<RangeBehaviour>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
