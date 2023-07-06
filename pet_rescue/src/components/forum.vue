<template>
	<div class="header">
		论坛
		<div class="avatar-small"><!--中间插入图片组件--></div>
	</div>
	<div class="line"></div>
	<div class="sidebar">
		<div class="avatar-large"></div>
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
	
	.sidebar {
		position: fixed;
		right: 0;
		top:10vh;
		width: 29%;
		height: 100%;
		background: #ffffff;
		display: flex; /* 将容器设置为弹性布局 */
		justify-content: center; /* 水平居中 */
	}
	
	.avatar-large {
		/*圆形 1*/
		display: fixed;
		border-radius: 50%;
		margin-top:10%;
		right: 12%;
		width: 150px;
		height: 150px;
		opacity: 1;
		background: #7A7A7A;
	}
	
	.line {
		/*直线 1*/	
		position: fixed;
		left: 70%;
		top: 0px;
		width: 0px;
		height: 100%;
		opacity: 1;
		border: 1px solid rgba(204, 204, 204, 1);
	}

</style>