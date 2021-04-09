/****************************************************************************
 * Copyright (c) 2021.4  liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using UnityEditor;

namespace QFramework
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AbstractAIBrain), true)]
    public class AbstractAIBrainEditor : Editor
    {
        protected ReorderableList mList;
        protected SerializedProperty mBrainActive;
        protected SerializedProperty mTimeInThisState;
        protected SerializedProperty mTarget;

        protected virtual void OnEnable()
        {
            mList = new ReorderableList(serializedObject.FindProperty("States"));
            mList.elementNameProperty = "States";
            mList.elementDisplayType = ReorderableList.ElementDisplayType.Expandable;

            mBrainActive = serializedObject.FindProperty("BrainActive");
            mTimeInThisState = serializedObject.FindProperty("TimeInThisState");
            mTarget = serializedObject.FindProperty("Target");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            mList.DoLayoutList();
            EditorGUILayout.PropertyField(mBrainActive);
            EditorGUILayout.PropertyField(mTimeInThisState);
            EditorGUILayout.PropertyField(mTarget);
            serializedObject.ApplyModifiedProperties();

            AbstractAIBrain brain = (AbstractAIBrain) target;
            if (brain.CurrentState != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Current State", brain.CurrentState.StateName);
            }
        }
    }
}