package crc64d6cce91cbfa85221;


public class GridViewActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Draft3.GridViewActivity, Draft3", GridViewActivity.class, __md_methods);
	}


	public GridViewActivity ()
	{
		super ();
		if (getClass () == GridViewActivity.class)
			mono.android.TypeManager.Activate ("Draft3.GridViewActivity, Draft3", "", this, new java.lang.Object[] {  });
	}

	public GridViewActivity (android.content.Context p0)
	{
		super ();
		if (getClass () == GridViewActivity.class)
			mono.android.TypeManager.Activate ("Draft3.GridViewActivity, Draft3", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
