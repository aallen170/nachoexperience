using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Sprite CurrentSprite { get; private set; }
    public PlayerState CurrentState { get; set; }

    public enum PlayerState
    {
        Idle,
        WalkingLeft,
        WalkingRight,
        UsingCellPhone,
        UsingMailbox
    }

    private GameObject m_player;

    //private List<Sprite> m_walkingLeftStrip;
    //private List<Sprite> m_walkingRightStrip;

    public Sprite[] m_walkingLeftStrip;
    public Sprite[] m_walkingRightStrip;

    private Sprite m_usingCellphone;
    private Sprite m_usingMailbox;

    private int m_currentFrame;
    private float m_currentFrameDelta;
      
    // Use this for initialization
    void Start ()
    {
        m_player = GameObject.Find("PlayerSprite");

        //m_walkingLeftStrip = new List<Sprite>();
        //m_walkingRightStrip = new List<Sprite>();

        //m_walkingLeftStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Left_4"));
        //m_walkingLeftStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Left_3"));
        //m_walkingLeftStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Left_2"));
        //m_walkingLeftStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Left_1"));
        //m_walkingLeftStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Left_0"));

        //m_walkingRightStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Right_0"));
        //m_walkingRightStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Right_1"));
        //m_walkingRightStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Right_2"));
        //m_walkingRightStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Right_3"));
        //m_walkingRightStrip.Add(Resources.Load<Sprite>("Sprites/Nacho/NachoWalkCycle_Right_4"));

        m_usingCellphone = Resources.Load<Sprite>("Sprites/Nacho/NachoHoldingPhone");
        m_usingMailbox = Resources.Load<Sprite>("Sprites/Nacho/Nacho_Mailbox");

        m_currentFrame = 0;
        CurrentState = PlayerState.Idle;
        m_currentFrameDelta = 0.0F;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentState == PlayerState.Idle)
        {
            CurrentSprite = m_walkingRightStrip[0];
            return;
        }

        if (CurrentState == PlayerState.UsingCellPhone)
        {
            CurrentSprite = m_usingCellphone;
            return;
        }

        if (CurrentState == PlayerState.UsingMailbox)
        {
            CurrentSprite = m_usingMailbox;
            return;
        }

        if (CurrentState == PlayerState.WalkingLeft)
        {
            m_currentFrameDelta += Time.deltaTime;

            if (m_currentFrameDelta > 0.1F)
            {
                m_currentFrameDelta = 0.0F;
                m_currentFrame++;
                if (m_currentFrame >= m_walkingLeftStrip.Length - 1)
                {
                    m_currentFrame = 0;
                }
            }
            CurrentSprite = m_walkingLeftStrip[m_currentFrame];
        }

        if (CurrentState == PlayerState.WalkingRight)
        {
            m_currentFrameDelta += Time.deltaTime;

            if (m_currentFrameDelta > 0.1F)
            {
                m_currentFrameDelta = 0.0F;
                m_currentFrame++;
                if (m_currentFrame > m_walkingRightStrip.Length - 1)
                {
                    m_currentFrame = 0;
                }
            }
            CurrentSprite = m_walkingRightStrip[m_currentFrame];
        }
	}
}
