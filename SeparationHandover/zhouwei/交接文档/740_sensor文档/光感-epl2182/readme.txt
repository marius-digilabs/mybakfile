elan_epl2182.c ����kernel\drivers\input\misc
elan_interface.h ����kernel\include\linux\input����
Makefile:��Ҫ���obj-$(CONFIG_SENSORS_ELAN_EPL2182)	+= elan_epl2182.o
Kconfig:��Ҫ����������ݣ�
config SENSORS_ELAN_EPL2182
	tristate "ELAN EPL2182 proximity and ambient light sensor"
	depends on I2C=y
	help
	  If you say yes here you get support for ELAN's light/proximity sensors epl2182.