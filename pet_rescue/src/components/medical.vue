<template>
	<div class="header">
		医疗服务
		<div class="avatar-small"><!--中间插入图片组件--></div>
	</div>
	<div class="image">
		<img src="./photos/宠物医疗.jpg" alt="计划轮播图">
	</div>
	<div class="doctor1">
		<!-- <img src="."> -->
	</div>
</template>

<script>
</script>

<style>
	.header {
	  position: fixed;
	  display: flex; /* 将容器设置为弹性布局 */
	  top: 0;
	  left: 0;
	  width: 100%;
	  height: 10vh;
	  background: rgba(204, 204, 204, 1);
	  margin: 0;
	  padding: 0;
	  padding-left: 2%;
	  align-items: center; /* 垂直居中 */
	  font-family: "等线", "Eras Light ITC", sans-serif; /* 设置字体为等线或等线字体的具体名称 */
	  font-size: 20px;
	}
	
	.avatar-small {
		/*圆形 1*/
		border-radius: 50%;
		position: fixed;
		right: 3%;
		width: 30px;
		height: 30px;
		opacity: 1;
		background: rgba(255, 255, 255, 1);
	}
	
	img {
	    width: 900px; /* 设置图片宽度 */
	    height: 600px; /* 设置图片高度 */
	    margin-top: 15vh; /* 设置图片上方边距 */
		margin-left: 6vh;
	    /* 添加其他样式 */
	  }
</style>