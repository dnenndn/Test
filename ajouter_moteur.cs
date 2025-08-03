using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x02000012 RID: 18
	public partial class ajouter_moteur : Form
	{
		// Token: 0x06000103 RID: 259 RVA: 0x0002F590 File Offset: 0x0002D790
		public ajouter_moteur()
		{
			this.InitializeComponent();
			this.load_arbre(0);
			this.radMenuItem1.Click += this.click_ajouter;
			this.Label15.TextChanged += this.Label15_TextChanged;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0002F5EB File Offset: 0x0002D7EB
		private void Label15_TextChanged(object sender, EventArgs e)
		{
			this.TextBox8.Text = this.Label15.Text;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0002F608 File Offset: 0x0002D808
		private void ajouter_moteur_Load(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radDateTimePicker2.Value = DateTime.Today;
			this.Label15.Text = "";
			this.Label25.Text = "";
			this.Label23.Hide();
			this.Label25.Hide();
			this.Label15.Hide();
			this.select_couplage();
			this.select_montage();
			this.select_frein();
			this.select_statut();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0002F698 File Offset: 0x0002D898
		private void select_couplage()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Y");
			this.radDropDownList1.Items.Add("Triangle");
			this.radDropDownList1.Items.Add("Y & Triangle");
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0002F6FC File Offset: 0x0002D8FC
		private void select_montage()
		{
			this.radDropDownList2.Items.Clear();
			this.radDropDownList2.Items.Add("B3");
			this.radDropDownList2.Items.Add("B6");
			this.radDropDownList2.Items.Add("B7");
			this.radDropDownList2.Items.Add("B8");
			this.radDropDownList2.Items.Add("B5");
			this.radDropDownList2.Items.Add("B14");
			this.radDropDownList2.Items.Add("B34");
			this.radDropDownList2.Items.Add("B35");
			this.radDropDownList2.Items.Add("V1");
			this.radDropDownList2.Items.Add("V5");
			this.radDropDownList2.Items.Add("V18");
			this.radDropDownList2.Items.Add("V15");
			this.radDropDownList2.Items.Add("V6");
			this.radDropDownList2.Items.Add("V3");
			this.radDropDownList2.Items.Add("V19");
			this.radDropDownList2.Items.Add("V36");
			this.radDropDownList2.Items.Add("V58");
			this.radDropDownList2.Items.Add("V69");
			this.radDropDownList2.Items.Add("Pompe à eau");
			this.radDropDownList2.Items.Add("Pompe à huile");
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0002F8D4 File Offset: 0x0002DAD4
		private void select_frein()
		{
			this.radDropDownList3.Items.Clear();
			this.radDropDownList3.Items.Add("SF");
			this.radDropDownList3.Items.Add("FA");
			this.radDropDownList3.Items.Add("FC");
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0002F935 File Offset: 0x0002DB35
		private void BunifuCards1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0002F938 File Offset: 0x0002DB38
		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			this.TextBox6.Text = "";
			this.TextBox7.Text = "";
			this.TextBox5.Text = "";
			bool flag = fonction.DeleteSpace(this.TextBox2.Text) == "";
			if (flag)
			{
				this.Label15.Text = "";
				this.Label25.Text = "";
				this.TextBox6.Text = "";
				this.TextBox7.Text = "";
				this.TextBox5.Text = "";
			}
			else
			{
				bool flag2 = fonction.DeleteSpace(this.TextBox3.Text) == "";
				if (flag2)
				{
					this.Label15.Text = "";
					this.Label25.Text = "";
					this.TextBox6.Text = "";
					this.TextBox7.Text = "";
					this.TextBox5.Text = "";
				}
				else
				{
					bool flag3 = this.TextBox2.Text == "0,37";
					if (flag3)
					{
						bool flag4 = this.TextBox3.Text == "2";
						if (flag4)
						{
							this.Label15.Text = "0,98";
							this.Label25.Text = "11-63";
							this.TextBox7.Text = "23mm";
						}
						else
						{
							bool flag5 = this.TextBox3.Text == "4";
							if (flag5)
							{
								this.Label15.Text = "1,06";
								this.Label25.Text = "14-71";
								this.TextBox7.Text = "30mm";
							}
							else
							{
								bool flag6 = this.TextBox3.Text == "6";
								if (flag6)
								{
									this.Label15.Text = "1,1";
									this.Label25.Text = "14-71";
									this.TextBox7.Text = "30mm";
								}
								else
								{
									this.Label15.Text = "";
									this.TextBox6.Text = "";
									this.TextBox7.Text = "";
									this.TextBox5.Text = "";
								}
							}
						}
					}
					else
					{
						bool flag7 = this.TextBox2.Text == "0,55";
						if (flag7)
						{
							bool flag8 = this.TextBox3.Text == "2";
							if (flag8)
							{
								this.Label15.Text = "1,32";
								this.Label25.Text = "19-80";
								this.TextBox7.Text = "40mm";
							}
							else
							{
								bool flag9 = this.TextBox3.Text == "4";
								if (flag9)
								{
									this.Label15.Text = "1,62";
									this.Label25.Text = "19-80";
									this.TextBox7.Text = "40mm";
								}
								else
								{
									bool flag10 = this.TextBox3.Text == "6";
									if (flag10)
									{
										this.Label15.Text = "1,8";
										this.Label25.Text = "24-90";
										this.TextBox7.Text = "50mm";
									}
									else
									{
										this.Label15.Text = "";
										this.TextBox6.Text = "";
										this.TextBox7.Text = "";
										this.TextBox5.Text = "";
									}
								}
							}
						}
						else
						{
							bool flag11 = this.TextBox2.Text == "0,75";
							if (flag11)
							{
								bool flag12 = this.TextBox3.Text == "2";
								if (flag12)
								{
									this.Label15.Text = "1,7";
									this.Label25.Text = "19-80";
									this.TextBox7.Text = "40mm";
								}
								else
								{
									bool flag13 = this.TextBox3.Text == "4";
									if (flag13)
									{
										this.Label15.Text = "2,01";
										this.Label25.Text = "19-80";
										this.TextBox7.Text = "40mm";
									}
									else
									{
										bool flag14 = this.TextBox3.Text == "6";
										if (flag14)
										{
											this.Label15.Text = "2,1";
											this.Label25.Text = "24-90";
											this.TextBox7.Text = "50mm";
										}
										else
										{
											this.Label15.Text = "";
											this.TextBox6.Text = "";
											this.TextBox7.Text = "";
											this.TextBox5.Text = "";
										}
									}
								}
							}
							else
							{
								bool flag15 = this.TextBox2.Text == "1,1";
								if (flag15)
								{
									bool flag16 = this.TextBox3.Text == "2";
									if (flag16)
									{
										this.Label15.Text = "2,4";
										this.Label25.Text = "19-80";
										this.TextBox7.Text = "40mm";
									}
									else
									{
										bool flag17 = this.TextBox3.Text == "4";
										if (flag17)
										{
											this.Label15.Text = "2,5";
											this.Label25.Text = "24-90";
											this.TextBox7.Text = "50mm";
										}
										else
										{
											bool flag18 = this.TextBox3.Text == "6";
											if (flag18)
											{
												this.Label15.Text = "3";
												this.Label25.Text = "24-90";
												this.TextBox7.Text = "50mm";
											}
											else
											{
												this.Label15.Text = "";
												this.TextBox6.Text = "";
												this.TextBox7.Text = "";
												this.TextBox5.Text = "";
											}
										}
									}
								}
								else
								{
									bool flag19 = this.TextBox2.Text == "1,5";
									if (flag19)
									{
										bool flag20 = this.TextBox3.Text == "2";
										if (flag20)
										{
											this.Label15.Text = "3,2";
											this.Label25.Text = "24-90";
											this.TextBox7.Text = "50mm";
										}
										else
										{
											bool flag21 = this.TextBox3.Text == "4";
											if (flag21)
											{
												this.Label15.Text = "3,4";
												this.Label25.Text = "24-90";
												this.TextBox7.Text = "50mm";
											}
											else
											{
												bool flag22 = this.TextBox3.Text == "6";
												if (flag22)
												{
													this.Label15.Text = "4,2";
													this.Label25.Text = "80-100";
													this.TextBox7.Text = "60mm";
												}
												else
												{
													this.Label15.Text = "";
													this.TextBox6.Text = "";
													this.TextBox7.Text = "";
													this.TextBox5.Text = "";
												}
											}
										}
									}
									else
									{
										bool flag23 = this.TextBox2.Text == "2,2";
										if (flag23)
										{
											bool flag24 = this.TextBox3.Text == "2";
											if (flag24)
											{
												this.Label15.Text = "4,3";
												this.Label25.Text = "24-90";
												this.TextBox7.Text = "50mm";
											}
											else
											{
												bool flag25 = this.TextBox3.Text == "4";
												if (flag25)
												{
													this.Label15.Text = "4,8";
													this.Label25.Text = "28-100";
													this.TextBox7.Text = "60mm";
												}
												else
												{
													bool flag26 = this.TextBox3.Text == "6";
													if (flag26)
													{
														this.Label15.Text = "5,8";
														this.Label25.Text = "28-112";
														this.TextBox7.Text = "60mm";
													}
													else
													{
														this.Label15.Text = "";
														this.TextBox6.Text = "";
														this.TextBox7.Text = "";
														this.TextBox5.Text = "";
													}
												}
											}
										}
										else
										{
											bool flag27 = this.TextBox2.Text == "3";
											if (flag27)
											{
												bool flag28 = this.TextBox3.Text == "2";
												if (flag28)
												{
													this.Label15.Text = "6,3";
													this.Label25.Text = "28-100";
													this.TextBox7.Text = "60mm";
												}
												else
												{
													bool flag29 = this.TextBox3.Text == "4";
													if (flag29)
													{
														this.Label15.Text = "6,5";
														this.Label25.Text = "28-100";
														this.TextBox7.Text = "60mm";
													}
													else
													{
														bool flag30 = this.TextBox3.Text == "6";
														if (flag30)
														{
															this.Label15.Text = "6,8";
															this.Label25.Text = "38-132";
															this.TextBox7.Text = "80mm";
														}
														else
														{
															this.Label15.Text = "";
															this.TextBox6.Text = "";
															this.TextBox7.Text = "";
															this.TextBox5.Text = "";
														}
													}
												}
											}
											else
											{
												bool flag31 = this.TextBox2.Text == "4";
												if (flag31)
												{
													bool flag32 = this.TextBox3.Text == "2";
													if (flag32)
													{
														this.Label15.Text = "7,8";
														this.Label25.Text = "28-112";
														this.TextBox7.Text = "60mm";
													}
													else
													{
														bool flag33 = this.TextBox3.Text == "4";
														if (flag33)
														{
															this.Label15.Text = "8,3";
															this.Label25.Text = "28-112";
															this.TextBox7.Text = "60mm";
														}
														else
														{
															bool flag34 = this.TextBox3.Text == "6";
															if (flag34)
															{
																this.Label15.Text = "9,3";
																this.Label25.Text = "38-132";
																this.TextBox7.Text = "80mm";
															}
															else
															{
																this.Label15.Text = "";
																this.TextBox6.Text = "";
																this.TextBox7.Text = "";
																this.TextBox5.Text = "";
															}
														}
													}
												}
												else
												{
													bool flag35 = this.TextBox2.Text == "5,5";
													if (flag35)
													{
														bool flag36 = this.TextBox3.Text == "2";
														if (flag36)
														{
															this.Label15.Text = "10,5";
															this.Label25.Text = "38-132";
															this.TextBox7.Text = "80mm";
														}
														else
														{
															bool flag37 = this.TextBox3.Text == "4";
															if (flag37)
															{
																this.Label15.Text = "11,1";
																this.Label25.Text = "38-132";
																this.TextBox7.Text = "80mm";
															}
															else
															{
																bool flag38 = this.TextBox3.Text == "6";
																if (flag38)
																{
																	this.Label15.Text = "13,3";
																	this.Label25.Text = "38-132";
																	this.TextBox7.Text = "80mm";
																}
																else
																{
																	this.Label15.Text = "";
																	this.TextBox6.Text = "";
																	this.TextBox7.Text = "";
																	this.TextBox5.Text = "";
																}
															}
														}
													}
													else
													{
														bool flag39 = this.TextBox2.Text == "7,5";
														if (flag39)
														{
															bool flag40 = this.TextBox3.Text == "2";
															if (flag40)
															{
																this.Label15.Text = "14,7";
																this.Label25.Text = "38-132";
																this.TextBox7.Text = "80mm";
															}
															else
															{
																bool flag41 = this.TextBox3.Text == "4";
																if (flag41)
																{
																	this.Label15.Text = "15,2";
																	this.Label25.Text = "38-132";
																	this.TextBox7.Text = "80mm";
																}
																else
																{
																	bool flag42 = this.TextBox3.Text == "6";
																	if (flag42)
																	{
																		this.Label15.Text = "16,3";
																		this.Label25.Text = "42-160";
																		this.TextBox7.Text = "110mm";
																	}
																	else
																	{
																		this.Label15.Text = "";
																		this.TextBox6.Text = "";
																		this.TextBox7.Text = "";
																		this.TextBox5.Text = "";
																	}
																}
															}
														}
														else
														{
															bool flag43 = this.TextBox2.Text == "9";
															if (flag43)
															{
																bool flag44 = this.TextBox3.Text == "2";
																if (flag44)
																{
																	this.Label15.Text = "17,3";
																	this.Label25.Text = "38-132";
																	this.TextBox7.Text = "80mm";
																}
																else
																{
																	bool flag45 = this.TextBox3.Text == "4";
																	if (flag45)
																	{
																		this.Label15.Text = "18,1";
																		this.Label25.Text = "38-132";
																		this.TextBox7.Text = "100mm";
																	}
																	else
																	{
																		bool flag46 = this.TextBox3.Text == "6";
																		if (flag46)
																		{
																			this.Label15.Text = "13,3";
																			this.Label25.Text = "38-132";
																			this.TextBox7.Text = "80mm";
																		}
																		else
																		{
																			this.Label15.Text = "";
																			this.TextBox6.Text = "";
																			this.TextBox7.Text = "";
																			this.TextBox5.Text = "";
																		}
																	}
																}
															}
															else
															{
																bool flag47 = this.TextBox2.Text == "11";
																if (flag47)
																{
																	bool flag48 = this.TextBox3.Text == "2";
																	if (flag48)
																	{
																		this.Label15.Text = "20,7";
																		this.Label25.Text = "42-160";
																		this.TextBox7.Text = "110mm";
																	}
																	else
																	{
																		bool flag49 = this.TextBox3.Text == "4";
																		if (flag49)
																		{
																			this.Label15.Text = "21";
																			this.Label25.Text = "42-160";
																			this.TextBox7.Text = "110mm";
																		}
																		else
																		{
																			bool flag50 = this.TextBox3.Text == "6";
																			if (flag50)
																			{
																				this.Label15.Text = "23,4";
																				this.Label25.Text = "42-160";
																				this.TextBox7.Text = "110mm";
																			}
																			else
																			{
																				this.Label15.Text = "";
																				this.TextBox6.Text = "";
																				this.TextBox7.Text = "";
																				this.TextBox5.Text = "";
																			}
																		}
																	}
																}
																else
																{
																	bool flag51 = this.TextBox2.Text == "15";
																	if (flag51)
																	{
																		bool flag52 = this.TextBox3.Text == "2";
																		if (flag52)
																		{
																			this.Label15.Text = "28,4";
																			this.Label25.Text = "42-160";
																			this.TextBox7.Text = "110mm";
																		}
																		else
																		{
																			bool flag53 = this.TextBox3.Text == "4";
																			if (flag53)
																			{
																				this.Label15.Text = "28,8";
																				this.Label25.Text = "42-160";
																				this.TextBox7.Text = "110mm";
																			}
																			else
																			{
																				bool flag54 = this.TextBox3.Text == "6";
																				if (flag54)
																				{
																					this.Label15.Text = "31,9";
																					this.Label25.Text = "48-180";
																					this.TextBox7.Text = "110mm";
																				}
																				else
																				{
																					this.Label15.Text = "";
																					this.TextBox6.Text = "";
																					this.TextBox7.Text = "";
																					this.TextBox5.Text = "";
																				}
																			}
																		}
																	}
																	else
																	{
																		bool flag55 = this.TextBox2.Text == "18,5";
																		if (flag55)
																		{
																			bool flag56 = this.TextBox3.Text == "2";
																			if (flag56)
																			{
																				this.Label15.Text = "33,7";
																				this.Label25.Text = "42-160";
																				this.TextBox7.Text = "110mm";
																			}
																			else
																			{
																				bool flag57 = this.TextBox3.Text == "4";
																				if (flag57)
																				{
																					this.Label15.Text = "35,2";
																					this.Label25.Text = "48-180";
																					this.TextBox7.Text = "110mm";
																				}
																				else
																				{
																					bool flag58 = this.TextBox3.Text == "6";
																					if (flag58)
																					{
																						this.Label15.Text = "37";
																						this.Label25.Text = "55-200";
																						this.TextBox7.Text = "110mm";
																					}
																					else
																					{
																						this.Label15.Text = "";
																						this.TextBox6.Text = "";
																						this.TextBox7.Text = "";
																						this.TextBox5.Text = "";
																					}
																				}
																			}
																		}
																		else
																		{
																			bool flag59 = this.TextBox2.Text == "22";
																			if (flag59)
																			{
																				bool flag60 = this.TextBox3.Text == "2";
																				if (flag60)
																				{
																					this.Label15.Text = "39,9";
																					this.Label25.Text = "48-180";
																					this.TextBox7.Text = "110mm";
																				}
																				else
																				{
																					bool flag61 = this.TextBox3.Text == "4";
																					if (flag61)
																					{
																						this.Label15.Text = "41,7";
																						this.Label25.Text = "48-180";
																						this.TextBox7.Text = "110mm";
																					}
																					else
																					{
																						bool flag62 = this.TextBox3.Text == "6";
																						if (flag62)
																						{
																							this.Label15.Text = "43,6";
																							this.Label25.Text = "55-200";
																							this.TextBox7.Text = "110mm";
																						}
																						else
																						{
																							this.Label15.Text = "";
																							this.TextBox6.Text = "";
																							this.TextBox7.Text = "";
																							this.TextBox5.Text = "";
																						}
																					}
																				}
																			}
																			else
																			{
																				bool flag63 = this.TextBox2.Text == "30";
																				if (flag63)
																				{
																					bool flag64 = this.TextBox3.Text == "2";
																					if (flag64)
																					{
																						this.Label15.Text = "52,1";
																						this.Label25.Text = "55-200";
																						this.TextBox7.Text = "110mm";
																					}
																					else
																					{
																						bool flag65 = this.TextBox3.Text == "4";
																						if (flag65)
																						{
																							this.Label15.Text = "56,3";
																							this.Label25.Text = "55-200";
																							this.TextBox7.Text = "110mm";
																						}
																						else
																						{
																							bool flag66 = this.TextBox3.Text == "6";
																							if (flag66)
																							{
																								this.Label15.Text = "59,5";
																								this.Label25.Text = "60-225";
																								this.TextBox7.Text = "140mm";
																							}
																							else
																							{
																								this.Label15.Text = "";
																								this.TextBox6.Text = "";
																								this.TextBox7.Text = "";
																								this.TextBox5.Text = "";
																							}
																						}
																					}
																				}
																				else
																				{
																					bool flag67 = this.TextBox2.Text == "37";
																					if (flag67)
																					{
																						bool flag68 = this.TextBox3.Text == "2";
																						if (flag68)
																						{
																							this.Label15.Text = "65";
																							this.Label25.Text = "55-200";
																							this.TextBox7.Text = "110mm";
																						}
																						else
																						{
																							bool flag69 = this.TextBox3.Text == "4";
																							if (flag69)
																							{
																								this.Label15.Text = "69";
																								this.Label25.Text = "60-225";
																								this.TextBox7.Text = "140mm";
																							}
																							else
																							{
																								bool flag70 = this.TextBox3.Text == "6";
																								if (flag70)
																								{
																									this.Label15.Text = "71,1";
																									this.Label25.Text = "65-250";
																									this.TextBox7.Text = "140mm";
																								}
																								else
																								{
																									this.Label15.Text = "";
																									this.TextBox6.Text = "";
																									this.TextBox7.Text = "";
																									this.TextBox5.Text = "";
																								}
																							}
																						}
																					}
																					else
																					{
																						bool flag71 = this.TextBox2.Text == "45";
																						if (flag71)
																						{
																							bool flag72 = this.TextBox3.Text == "2";
																							if (flag72)
																							{
																								this.Label15.Text = "78";
																								this.Label25.Text = "55-225";
																								this.TextBox7.Text = "110mm";
																							}
																							else
																							{
																								bool flag73 = this.TextBox3.Text == "4";
																								if (flag73)
																								{
																									this.Label15.Text = "84";
																									this.Label25.Text = "60-225";
																									this.TextBox7.Text = "140mm";
																								}
																								else
																								{
																									bool flag74 = this.TextBox3.Text == "6";
																									if (flag74)
																									{
																										this.Label15.Text = "86,5";
																										this.Label25.Text = "75-280";
																										this.TextBox7.Text = "140mm";
																									}
																									else
																									{
																										this.Label15.Text = "";
																										this.TextBox6.Text = "";
																										this.TextBox7.Text = "";
																										this.TextBox5.Text = "";
																									}
																								}
																							}
																						}
																						else
																						{
																							bool flag75 = this.TextBox2.Text == "55";
																							if (flag75)
																							{
																								bool flag76 = this.TextBox3.Text == "2";
																								if (flag76)
																								{
																									this.Label15.Text = "96";
																									this.Label25.Text = "60-250";
																									this.TextBox7.Text = "240mm";
																								}
																								else
																								{
																									bool flag77 = this.TextBox3.Text == "4";
																									if (flag77)
																									{
																										this.Label15.Text = "102";
																										this.Label25.Text = "65-250";
																										this.TextBox7.Text = "140mm";
																									}
																									else
																									{
																										bool flag78 = this.TextBox3.Text == "6";
																										if (flag78)
																										{
																											this.Label15.Text = "106";
																											this.Label25.Text = "75-280";
																											this.TextBox7.Text = "140mm";
																										}
																										else
																										{
																											this.Label15.Text = "";
																											this.TextBox6.Text = "";
																											this.TextBox7.Text = "";
																											this.TextBox5.Text = "";
																										}
																									}
																								}
																							}
																							else
																							{
																								bool flag79 = this.TextBox2.Text == "75";
																								if (flag79)
																								{
																									bool flag80 = this.TextBox3.Text == "2";
																									if (flag80)
																									{
																										this.Label15.Text = "129";
																										this.Label25.Text = "65-280";
																										this.TextBox7.Text = "140mm";
																									}
																									else
																									{
																										bool flag81 = this.TextBox3.Text == "4";
																										if (flag81)
																										{
																											this.Label15.Text = "138";
																											this.Label25.Text = "75-280";
																											this.TextBox7.Text = "140mm";
																										}
																										else
																										{
																											bool flag82 = this.TextBox3.Text == "6";
																											if (flag82)
																											{
																												this.Label15.Text = "142";
																												this.Label25.Text = "80-315";
																												this.TextBox7.Text = "170mm";
																											}
																											else
																											{
																												this.Label15.Text = "";
																												this.TextBox6.Text = "";
																												this.TextBox7.Text = "";
																												this.TextBox5.Text = "";
																											}
																										}
																									}
																								}
																								else
																								{
																									bool flag83 = this.TextBox2.Text == "90";
																									if (flag83)
																									{
																										bool flag84 = this.TextBox3.Text == "2";
																										if (flag84)
																										{
																											this.Label15.Text = "154";
																											this.Label25.Text = "65-280";
																											this.TextBox7.Text = "140mm";
																										}
																										else
																										{
																											bool flag85 = this.TextBox3.Text == "4";
																											if (flag85)
																											{
																												this.Label15.Text = "165";
																												this.Label25.Text = "75-280";
																												this.TextBox7.Text = "140mm";
																											}
																											else
																											{
																												bool flag86 = this.TextBox3.Text == "6";
																												if (flag86)
																												{
																													this.Label15.Text = "164";
																													this.Label25.Text = "80-315";
																													this.TextBox7.Text = "170mm";
																												}
																												else
																												{
																													this.Label15.Text = "";
																													this.TextBox6.Text = "";
																													this.TextBox7.Text = "";
																													this.TextBox5.Text = "";
																												}
																											}
																										}
																									}
																									else
																									{
																										bool flag87 = this.TextBox2.Text == "110";
																										if (flag87)
																										{
																											bool flag88 = this.TextBox3.Text == "2";
																											if (flag88)
																											{
																												this.Label15.Text = "184";
																												this.Label25.Text = "65-315";
																												this.TextBox7.Text = "140mm";
																											}
																											else
																											{
																												bool flag89 = this.TextBox3.Text == "4";
																												if (flag89)
																												{
																													this.Label15.Text = "201";
																													this.Label25.Text = "80-315";
																													this.TextBox7.Text = "170mm";
																												}
																												else
																												{
																													bool flag90 = this.TextBox3.Text == "6";
																													if (flag90)
																													{
																														this.Label15.Text = "200";
																														this.Label25.Text = "80-315";
																														this.TextBox7.Text = "170mm";
																													}
																													else
																													{
																														this.Label15.Text = "";
																														this.TextBox6.Text = "";
																														this.TextBox7.Text = "";
																														this.TextBox5.Text = "";
																													}
																												}
																											}
																										}
																										else
																										{
																											bool flag91 = this.TextBox2.Text == "132";
																											if (flag91)
																											{
																												bool flag92 = this.TextBox3.Text == "2";
																												if (flag92)
																												{
																													this.Label15.Text = "227";
																													this.Label25.Text = "65-315";
																													this.TextBox7.Text = "140mm";
																												}
																												else
																												{
																													bool flag93 = this.TextBox3.Text == "4";
																													if (flag93)
																													{
																														this.Label15.Text = "238";
																														this.Label25.Text = "80-315";
																														this.TextBox7.Text = "170mm";
																													}
																													else
																													{
																														bool flag94 = this.TextBox3.Text == "6";
																														if (flag94)
																														{
																															this.Label15.Text = "242";
																															this.Label25.Text = "80-315";
																															this.TextBox7.Text = "170mm";
																														}
																														else
																														{
																															this.Label15.Text = "";
																															this.TextBox6.Text = "";
																															this.TextBox7.Text = "";
																															this.TextBox5.Text = "";
																														}
																													}
																												}
																											}
																											else
																											{
																												bool flag95 = this.TextBox2.Text == "160";
																												if (flag95)
																												{
																													bool flag96 = this.TextBox3.Text == "2";
																													if (flag96)
																													{
																														this.Label15.Text = "271";
																														this.Label25.Text = "65-315";
																														this.TextBox7.Text = "140mm";
																													}
																													else
																													{
																														bool flag97 = this.TextBox3.Text == "4";
																														if (flag97)
																														{
																															this.Label15.Text = "287";
																															this.Label25.Text = "80-315";
																															this.TextBox7.Text = "170mm";
																														}
																														else
																														{
																															bool flag98 = this.TextBox3.Text == "6";
																															if (flag98)
																															{
																																this.Label15.Text = "287";
																																this.Label25.Text = "80-315";
																																this.TextBox7.Text = "170mm";
																															}
																															else
																															{
																																this.Label15.Text = "";
																																this.TextBox6.Text = "";
																																this.TextBox7.Text = "";
																																this.TextBox5.Text = "";
																															}
																														}
																													}
																												}
																												else
																												{
																													bool flag99 = this.TextBox2.Text == "200";
																													if (flag99)
																													{
																														bool flag100 = this.TextBox3.Text == "2";
																														if (flag100)
																														{
																															this.Label15.Text = "350";
																															this.Label25.Text = "65-315";
																															this.TextBox7.Text = "140mm";
																														}
																														else
																														{
																															bool flag101 = this.TextBox3.Text == "4";
																															if (flag101)
																															{
																																this.Label15.Text = "362";
																																this.Label25.Text = "80-315";
																																this.TextBox7.Text = "170mm";
																															}
																															else
																															{
																																bool flag102 = this.TextBox3.Text == "6";
																																if (flag102)
																																{
																																	this.Label15.Text = "362";
																																	this.Label25.Text = "80-315";
																																	this.TextBox7.Text = "170mm";
																																}
																																else
																																{
																																	this.Label15.Text = "";
																																	this.TextBox6.Text = "";
																																	this.TextBox7.Text = "";
																																	this.TextBox5.Text = "";
																																}
																															}
																														}
																													}
																													else
																													{
																														bool flag103 = this.TextBox2.Text == "250";
																														if (flag103)
																														{
																															bool flag104 = this.TextBox3.Text == "2";
																															if (flag104)
																															{
																																this.Label15.Text = "434";
																																this.Label25.Text = "85-355";
																																this.TextBox7.Text = "170mm";
																															}
																															else
																															{
																																bool flag105 = this.TextBox3.Text == "4";
																																if (flag105)
																																{
																																	this.Label15.Text = "434";
																																	this.Label25.Text = "100-355";
																																	this.TextBox7.Text = "210mm";
																																}
																																else
																																{
																																	this.Label15.Text = "";
																																	this.TextBox6.Text = "";
																																	this.TextBox7.Text = "";
																																	this.TextBox5.Text = "";
																																}
																															}
																														}
																														else
																														{
																															bool flag106 = this.TextBox2.Text == "315";
																															if (flag106)
																															{
																																bool flag107 = this.TextBox3.Text == "2";
																																if (flag107)
																																{
																																	this.Label15.Text = "556";
																																	this.Label25.Text = "85-355";
																																	this.TextBox7.Text = "170mm";
																																}
																																else
																																{
																																	bool flag108 = this.TextBox3.Text == "4";
																																	if (flag108)
																																	{
																																		this.Label15.Text = "556";
																																		this.Label25.Text = "100-355";
																																		this.TextBox7.Text = "210mm";
																																	}
																																	else
																																	{
																																		this.Label15.Text = "";
																																		this.TextBox6.Text = "";
																																		this.TextBox7.Text = "";
																																		this.TextBox5.Text = "";
																																	}
																																}
																															}
																															else
																															{
																																bool flag109 = this.TextBox2.Text == "355";
																																if (flag109)
																																{
																																	bool flag110 = this.TextBox3.Text == "2";
																																	if (flag110)
																																	{
																																		this.Label15.Text = "630";
																																		this.Label25.Text = "85-355";
																																		this.TextBox7.Text = "170mm";
																																	}
																																	else
																																	{
																																		bool flag111 = this.TextBox3.Text == "4";
																																		if (flag111)
																																		{
																																			this.Label15.Text = "630";
																																			this.Label25.Text = "100-355";
																																			this.TextBox7.Text = "210mm";
																																		}
																																		else
																																		{
																																			this.Label15.Text = "";
																																			this.TextBox6.Text = "";
																																			this.TextBox7.Text = "";
																																			this.TextBox5.Text = "";
																																		}
																																	}
																																}
																																else
																																{
																																	bool flag112 = this.TextBox2.Text == "400";
																																	if (flag112)
																																	{
																																		bool flag113 = this.TextBox3.Text == "2";
																																		if (flag113)
																																		{
																																			this.Label15.Text = "654";
																																			this.Label25.Text = "85-400";
																																			this.TextBox7.Text = "170mm";
																																		}
																																		else
																																		{
																																			bool flag114 = this.TextBox3.Text == "4";
																																			if (flag114)
																																			{
																																				this.Label15.Text = "654";
																																				this.Label25.Text = "100-400";
																																				this.TextBox7.Text = "210mm";
																																			}
																																			else
																																			{
																																				this.Label15.Text = "";
																																				this.TextBox6.Text = "";
																																				this.TextBox7.Text = "";
																																				this.TextBox5.Text = "";
																																			}
																																		}
																																	}
																																	else
																																	{
																																		this.Label15.Text = "";
																																		this.Label25.Text = "";
																																		this.TextBox6.Text = "";
																																		this.TextBox7.Text = "";
																																		this.TextBox5.Text = "";
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00032220 File Offset: 0x00030420
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			this.TextBox2_TextChanged(sender, e);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0003222C File Offset: 0x0003042C
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.PictureBox1.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00032280 File Offset: 0x00030480
		private void radDropDownList2_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList2.Text == "B3";
			if (flag)
			{
				this.Label10.Text = "Moteur à pattes(arbre horizontal,pattes au sol)";
				this.PictureBox3.Image = Resources.B33;
			}
			else
			{
				bool flag2 = this.radDropDownList2.Text == "B6";
				if (flag2)
				{
					this.Label10.Text = "Moteur à pattes(arbre horizontal,pattes au mur à gauche vue du bout d'arbre)";
					this.PictureBox3.Image = Resources.B6;
				}
				else
				{
					bool flag3 = this.radDropDownList2.Text == "B7";
					if (flag3)
					{
						this.Label10.Text = "Moteur à pattes(arbre horizontal,pattes au mur à droite vue du bout d'arbre)";
						this.PictureBox3.Image = Resources.B7;
					}
					else
					{
						bool flag4 = this.radDropDownList2.Text == "B8";
						if (flag4)
						{
							this.Label10.Text = "Moteur à pattes(arbre horizontal,pattes en haut)";
							this.PictureBox3.Image = Resources.B8;
						}
						else
						{
							bool flag5 = this.radDropDownList2.Text == "V5";
							if (flag5)
							{
								this.Label10.Text = "Moteur à pattes(arbre vertical vers le bas,pattes au mur)";
								this.PictureBox3.Image = Resources.V5;
							}
							else
							{
								bool flag6 = this.radDropDownList2.Text == "V6";
								if (flag6)
								{
									this.Label10.Text = "Moteur à pattes(arbre vertical vers le haut,pattes au mur)";
									this.PictureBox3.Image = Resources.V6;
								}
								else
								{
									bool flag7 = this.radDropDownList2.Text == "B5";
									if (flag7)
									{
										this.Label10.Text = "Moteur à bride à trous lisse(arbre horizontal)";
										this.PictureBox3.Image = Resources.B5;
									}
									else
									{
										bool flag8 = this.radDropDownList2.Text == "V1";
										if (flag8)
										{
											this.Label10.Text = "Moteur à bride à trous lisse(arbre vertical en bas)";
											this.PictureBox3.Image = Resources.V1;
										}
										else
										{
											bool flag9 = this.radDropDownList2.Text == "V3";
											if (flag9)
											{
												this.Label10.Text = "Moteur à bride à trous lisse(arbre vertical en haut)";
												this.PictureBox3.Image = Resources.V3;
											}
											else
											{
												bool flag10 = this.radDropDownList2.Text == "B35";
												if (flag10)
												{
													this.Label10.Text = "Moteur à bride à trous lisse(arbre horizontal,pattes au sol)";
													this.PictureBox3.Image = Resources.B35;
												}
												else
												{
													bool flag11 = this.radDropDownList2.Text == "V15";
													if (flag11)
													{
														this.Label10.Text = "Moteur à bride à trous lisse(arbre vertical en bas,pattes au mur)";
														this.PictureBox3.Image = Resources.v15;
													}
													else
													{
														bool flag12 = this.radDropDownList2.Text == "V36";
														if (flag12)
														{
															this.Label10.Text = "Moteur à bride à trous lisse(arbre vertical en haut,pattes au mur)";
															this.PictureBox3.Image = Resources.V36;
														}
														else
														{
															bool flag13 = this.radDropDownList2.Text == "B14";
															if (flag13)
															{
																this.Label10.Text = "Moteur à bride à trous taraudés(arbre horizontal)";
																this.PictureBox3.Image = Resources.B14;
															}
															else
															{
																bool flag14 = this.radDropDownList2.Text == "V18";
																if (flag14)
																{
																	this.Label10.Text = "Moteur à bride à trous taraudés(arbre vertical en bas)";
																	this.PictureBox3.Image = Resources.V18;
																}
																else
																{
																	bool flag15 = this.radDropDownList2.Text == "V19";
																	if (flag15)
																	{
																		this.Label10.Text = "Moteur à bride à trous taraudés(arbre vertical en haut)";
																		this.PictureBox3.Image = Resources.V19;
																	}
																	else
																	{
																		bool flag16 = this.radDropDownList2.Text == "B34";
																		if (flag16)
																		{
																			this.Label10.Text = "Moteur à bride à trous taraudés(arbre horizontal,pattes au sol)";
																			this.PictureBox3.Image = Resources.B34;
																		}
																		else
																		{
																			bool flag17 = this.radDropDownList2.Text == "V58";
																			if (flag17)
																			{
																				this.Label10.Text = "Moteur à bride à trous taraudés(arbre vertical en bas,pattes au mur)";
																				this.PictureBox3.Image = Resources.V58;
																			}
																			else
																			{
																				bool flag18 = this.radDropDownList2.Text == "V69";
																				if (flag18)
																				{
																					this.Label10.Text = "Moteur à bride à trous taraudés(arbre vertical en haut,pattes au mur)";
																					this.PictureBox3.Image = Resources.V69;
																				}
																				else
																				{
																					this.PictureBox3.Image = null;
																					this.Label10.Text = "";
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00032768 File Offset: 0x00030968
		private void Label25_TextChanged(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.Label25.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.Mid(this.Label25.Text, 3, 1) == "-";
				if (flag2)
				{
					this.TextBox6.Text = fonction.Mid(this.Label25.Text, 1, 2) + " mm";
					this.TextBox5.Text = fonction.Mid(this.Label25.Text, 4, this.Label25.Text.Length - 3) + " mm";
				}
				else
				{
					this.TextBox6.Text = fonction.Mid(this.Label25.Text, 1, 3) + " mm";
					this.TextBox5.Text = fonction.Mid(this.Label25.Text, 5, this.Label25.Text.Length - 4) + " mm";
				}
			}
			else
			{
				this.TextBox6.Text = "";
				this.TextBox5.Text = "";
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000328AE File Offset: 0x00030AAE
		private void Label15_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000328B4 File Offset: 0x00030AB4
		private void select_statut()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("En Service");
			this.radDropDownList4.Items.Add("En Atelier Rebobinage");
			this.radDropDownList4.Items.Add("En Magasin PDR");
			this.radDropDownList4.Items.Add("En Extérieure");
			this.radDropDownList4.Items.Add("En Défaillance");
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00032944 File Offset: 0x00030B44
		private void radDropDownList4_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			this.radDropDownList5.Items.Clear();
			bool flag = this.radDropDownList4.Text == "En Service";
			if (flag)
			{
				this.panel1.Visible = true;
				this.radDropDownList5.Items.Add("Demarrage Directe");
				this.radDropDownList5.Items.Add("Double Sens");
				this.radDropDownList5.Items.Add("Variateur");
				this.radDropDownList5.Items.Add("Demarreur");
				this.radDropDownList5.Items.Add("Etoile-Triangle");
			}
			else
			{
				this.panel1.Visible = false;
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00032A0C File Offset: 0x00030C0C
		public void load_arbre(int r)
		{
			this.arbre.DataSource = null;
			this.arbre.Nodes.Clear();
			DataTable dataTable = new DataTable();
			bd bd = new bd();
			string cmdText = "select id, designation from equipement where id_parent = @d and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter.Fill(dataTable2);
			string cmdText2 = "select id, code, designation, id_parent from equipement where deleted = @d and id_parent <> @d order by ordre";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@d", SqlDbType.TinyInt).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter2.Fill(dataTable3);
			dataTable.Columns.Clear();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("ParentID", typeof(int));
			dataTable.Columns.Add("Name", typeof(string));
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				dataTable.Rows.Add(new object[]
				{
					dataTable2.Rows[0].ItemArray[0].ToString(),
					null,
					dataTable2.Rows[0].ItemArray[1].ToString()
				});
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					dataTable.Rows.Add(new object[]
					{
						dataTable3.Rows[i].ItemArray[0].ToString(),
						dataTable3.Rows[i].ItemArray[3].ToString(),
						dataTable3.Rows[i].ItemArray[2].ToString()
					});
				}
				this.arbre.DataSource = dataTable;
				this.arbre.DisplayMember = "Name";
				this.arbre.ChildMember = "ID";
				this.arbre.ParentMember = "ParentID";
				this.arbre.ValueMember = "ID";
				this.arbre.Nodes[0].ImageIndex = 1;
				this.arbre.Nodes[0].Tag = dataTable.Rows[0].ItemArray[0].ToString();
				RadTreeNode n = this.arbre.Nodes[0];
				this.chargement_arbre(n);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00032CE0 File Offset: 0x00030EE0
		private void chargement_arbre(RadTreeNode n)
		{
			foreach (RadTreeNode radTreeNode in n.Nodes)
			{
				radTreeNode.Tag = radTreeNode.Value;
				radTreeNode.ImageIndex = 1;
				this.chargement_arbre(radTreeNode);
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00032D48 File Offset: 0x00030F48
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.arbre.ExpandAll();
			this.arbre.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00032D70 File Offset: 0x00030F70
		private void click_ajouter(object sender, EventArgs e)
		{
			this.radGridView1.Rows.Clear();
			bool flag = this.arbre.SelectedNode != null;
			if (flag)
			{
				string text = this.arbre.SelectedNode.Tag.ToString();
				string text2 = this.arbre.SelectedNode.Text.ToString();
				this.radGridView1.Rows.Add(new object[]
				{
					text,
					text2
				});
			}
		}
	}
}
