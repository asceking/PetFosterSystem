<template>
  <div class="cover">
    <!-- 封面图片显示区域 -->
    <!-- <img src="./photos/横屏背景.jpg" alt="封面图片" class="cover-image"> -->
	<!-- 用户头像容器 -->
	<div class="card">
	    <!-- Cover -->
	    <div class="card-cover">
			<img src="./photos/横屏背景.jpg" alt="封面图片" class="cover-image">
		</div>
	
	    <!-- Content -->
	    <div class="card-content"></div>
	    
	</div>
	<div>
	      <!-- 用户头像显示 -->
		<img src="./photos/猫狗亲昵.jpg" class="avatar-container">
	</div>
	
	<!-- 主页栏 -->
	<div class="cover1">
		<div class="text1">
			用户名：小黑
		</div>
		<div class="text2">
			ID：12345
		</div>
		<button class="button1">
			编辑资料
		</button>
		<div class="text3">
			我的帖子
		</div>
		<div class="text4">
			收藏
		</div>
		<div class="text5">
			消息
		</div>
		<div class="button2">
			<!-- <img src="photos/领养.jpg"/> -->
			我的领养
		</div>
		<div class="button3">
			我的寄养
		</div>
		<div class="button4">
			医疗记录
		</div>
		<div class="button5">
			我的捐款
		</div>
	</div>
	<div class="relevant">
		关于我们
	</div>
	
  </div>
</template>

<script>
export default {
  // 组件的逻辑代码
}
</script>

<style>
	.cover {
	  position: relative; /* 设置封面容器为相对定位，以便子元素进行定位 */
	  height: 100vh;
	  /* 添加其他自定义样式 */
	}
	
	.cover-image {
		height: 54vh; /* 设置封面高度，这里使用视口高度的55% */
	} 
	
	.cover1 {
		left: 0px;
		width: 100%;
		height: 331px;
		opacity: 1;
		background: rgba(204, 204, 204, 1);
	}
	
	.text1 {
		position: absolute;
		left: 50px;
		top: 500px;
		width: 500px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
	}
	
	.text2 {
		position: absolute;
		left: 50px;
		top: 540px;
		width: 500px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
	}
	
	.button1 {
		position: absolute;
		left: 50px;
		top: 580px;
		width: 100px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
		  display: flex; /* 将容器设置为弹性布局 */
		  justify-content: center; /* 水平居中 */
		  align-items: center; /* 垂直居中 */
	}
	
	.text3 {
		position: absolute;
		left: 350px;
		top: 580px;
		width: 100px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
	}
	
	.text4 {
		position: absolute;
		left: 550px;
		top: 580px;
		width: 100px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
	}
	
	.text5 {
		position: absolute;
		left: 750px;
		top: 580px;
		width: 100px;
		height: 40px;
		opacity: 1;
		font-size: 20px;
		font-weight: 400;
		letter-spacing: 0px;
		line-height: 43.44px;
		color: rgba(0, 0, 0, 1);
		text-align: left;
		vertical-align: top;
	}
	
	.button2 {
		position: absolute;
		left: 925px;
		top: 410px;
		width: 260px;
		height: 100px;
		opacity: 1;
		background: rgba(42, 130, 228, 1);
		display: flex; /* 将容器设置为弹性布局 */
		justify-content: center; /* 水平居中 */
		align-items: center; /* 垂直居中 */
		color: white; /* 设置文字颜色为白色 */
		font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
		font-size: 24px; /* 设置字体大小为24像素 */

	}
	
	.button3 {
		position: absolute;
		left: 1200px;
		top: 410px;
		width: 260px;
		height: 100px;
		opacity: 1;
		background: rgba(42, 130, 228, 1);
		display: flex; /* 将容器设置为弹性布局 */
		justify-content: center; /* 水平居中 */
		align-items: center; /* 垂直居中 */
		color: white; /* 设置文字颜色为白色 */
		font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
		font-size: 24px; /* 设置字体大小为24像素 */

	}
	
	.button4 {
		position: absolute;
		left: 925px;
		top: 525px;
		width: 260px;
		height: 100px;
		opacity: 1;
		background: rgba(42, 130, 228, 1);
		display: flex; /* 将容器设置为弹性布局 */
		justify-content: center; /* 水平居中 */
		align-items: center; /* 垂直居中 */
		color: white; /* 设置文字颜色为白色 */
		font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
		font-size: 24px; /* 设置字体大小为24像素 */
	}
	
	.button5 {
		position: absolute;
		left: 1200px;
		top: 525px;
		width: 260px;
		height: 100px;
		opacity: 1;
		background: rgba(42, 130, 228, 1);
		display: flex; /* 将容器设置为弹性布局 */
		justify-content: center; /* 水平居中 */
		align-items: center; /* 垂直居中 */
		color: white; /* 设置文字颜色为白色 */
		font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
		font-size: 24px; /* 设置字体大小为24像素 */
	}
	
	.avatar-container {
	  position: absolute;
	  left: 50px;
	  width: 150px;
	  height: 150px;
	  border-radius: 999px; /* 将border-radius设置为很大的值，使容器变成圆形 */
	  background-color: #fff;
	  /* 添加其他自定义样式 */
	}
	
	.card {
	    display: flex;
	    flex-direction: column;
	}
	
	.card-cover {
	    height: 20rem;
	    width: 100%;
	}
	
	.card-content {
	    /* Take available height */
	    flex: 1;
	}
	
	.tab {
	    /* Center the content */
	    align-items: center;
	    display: flex;
	    justify-content: center;
	}
	
	.tab__item {
	    border-top-left-radius: 0.25rem;
	    border-top-right-radius: 0.25rem;
	    padding: 0.5rem 1rem;
	}
	
	.tab__item--active {
	    /* Border */
	    border: 1px solid #d1d5db;
	    /* Hide the bottom border */
	    border-bottom-color: transparent;
	
	    /* Border radius */
	    border-top-left-radius: 2px;
	    border-top-right-radius: 2px;
	}
	
	.tab__item--inactive {
	    /* Has only the bottom border */
	    border-bottom: 1px solid #d1d5db;
	}
	
	.relevant {
		position: absolute;
		right:0px;
		height:100px;
		width:39%;
		background:#7A7A7A;
		color: white; /* 设置文字颜色为白色 */
		font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
		font-size: 24px; /* 设置字体大小为24像素 */
		padding: 20px;
	}
</style>
