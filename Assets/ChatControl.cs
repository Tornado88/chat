using UnityEngine;
using System.Collections;
using VoiceChat.Demo.HLAPI;
using VoiceChat.Demo;
using VoiceChat;

public class ChatControl : MonoBehaviour {

    VoiceChatNetworkManager vnm;

    // Use this for initialization
    void Start()
    {
        Invoke("ConfigStartClientHostLan", 0.8f);
        //Invoke("ConfigStartClientLan", 0.8f);
    }
	
	// Update is called once per frame
	void ConfigStartClientHostLan () {
        vnm = GetComponent<VoiceChatNetworkManager>();
        vnm.networkAddress = "172.16.3.82";
        vnm.networkPort = 7777;
        vnm.StartHost();

        foreach (string device in VoiceChatRecorder.Instance.AvailableDevices)
        {
            VoiceChatRecorder.Instance.Device = device;
            VoiceChatRecorder.Instance.StartRecording();
        }

        if (VoiceChatRecorder.Instance.Device != null)
        {

            VoiceChatRecorder.Instance.AutoDetectSpeech = true;
            //此处应该有个状态标识 已经可以聊天了
        }
    }

    void ConfigStartClientLan()
    {
        vnm = GetComponent<VoiceChatNetworkManager>();
        vnm.networkAddress = "172.16.3.82";
        vnm.networkPort = 7777;
        vnm.StartClient();

        foreach (string device in VoiceChatRecorder.Instance.AvailableDevices)
        {
            VoiceChatRecorder.Instance.Device = device;
            VoiceChatRecorder.Instance.StartRecording();
        }

        if (VoiceChatRecorder.Instance.Device != null)
        {

            VoiceChatRecorder.Instance.AutoDetectSpeech = true;
            //此处应该有个状态标识 已经可以聊天了
        }
    }
}
