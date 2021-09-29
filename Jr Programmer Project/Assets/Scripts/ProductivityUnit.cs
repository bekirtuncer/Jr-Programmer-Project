using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    private ResourcePile m_currentPile = null;
    public float ProductivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if(m_currentPile == null)
        {
            ResourcePile Pile = m_Target as ResourcePile;

            if(Pile != null)
            {
                m_currentPile = Pile;
                m_currentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
       if(m_currentPile != null)
        {
            m_currentPile.ProductionSpeed /= ProductivityMultiplier;
            m_currentPile = null;
        }
       
    }
    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
