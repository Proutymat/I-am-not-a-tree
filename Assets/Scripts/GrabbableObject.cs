using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrabbableObject : MonoBehaviour
{
    private Rigidbody _objectRigidBody;
    private Transform _objectGrabPointTransform;
    [SerializeField] private float lerpSpeed = 10.0f;
    [SerializeField] private Transform _hand;
    
    private Vector3 _originPosition;

    public Vector3 OriginPosition { get { return _originPosition; } }
    
    [Header("Sounds")]
    public AudioClip grabObjSound;
    [SerializeField] private AudioClip dropObjSound;
    private AudioSource audioSourceObject;
    [SerializeField] private Collider _triggerCollider;
    public void  SetTriggerCollider(bool triggerCollider)
    {
        if(_triggerCollider == null) 
        {
            Collider[] collids = GetComponents<Collider>();
            _triggerCollider = collids[0].isTrigger ? collids[0] : collids[1];
        }
        _triggerCollider.enabled = triggerCollider;
    }

    private void Awake()
    {
        _objectRigidBody = GetComponent<Rigidbody>();
        audioSourceObject = GetComponent<AudioSource>();
        _originPosition = transform.position;
    }
    private void Start()
    {
        Collider[] collids = GetComponents<Collider>();
        _triggerCollider = collids[0].isTrigger ? collids[0] : collids[1];
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this._objectGrabPointTransform = objectGrabPointTransform;
        _objectRigidBody.isKinematic = true;
        SetTriggerCollider(false);
    }
    
    public void Drop()
    {
        this._objectGrabPointTransform = null;
        _objectRigidBody.isKinematic = true;
        _objectGrabPointTransform = null;
        //_objectRigidBody.AddForce(500 * _hand.forward);
        SetTriggerCollider(true);
    }

    public void StopGrap() 
    {
        this._objectGrabPointTransform = null;
    }
    private void FixedUpdate()
    {
        if (_objectGrabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, _objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            _objectRigidBody.MovePosition(newPosition);
        }
    }
}