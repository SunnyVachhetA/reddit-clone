import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  logo : string 
  = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFwAAABcCAMAAADUMSJqAAAAkFBMVEX/RQD/////QAD/NgD/PAD/MQD/KwD//fz/6ub/+vj/8vD/29b/9/X/JgD/8O3/9fL/TSv/VC//zMT/opL/wLf/Z0z/4Nv/0sv/mIj/1tD/h3L/WTz/RAv/YEH/b1n/p5j/fGj/sqT/dV7/TBr/xrv/t67/koX/AAD/mJD/c2T/TCP/bFL/lYH/jXn/gmr/XzqC0PT5AAADrElEQVRoge1Y25qiMAy26QEEATkrggoos4szzvu/3eKBcVqKMMJcLf+V5mv/hCRN0s5mEyZMmDBhCACE/5hSMhI3yaLcoORLAzul4WGFR6Ene4SQdnAzuGlgB3SBlY3BTo/oBkX1ihN+8+q/CXRv7gLW0Tw0UU2p17/QGg8nX5pINeIyOq4XiIOyGWw6+Agd6AwIxrH97unKg90fTE7eESrusas0MG9McuogtH2wkOKLW42Hcs9IgLTvLMyqyVeDAwqbBQrYd0Fyj+txeLJAhlDK0ZDyaFYZGY2QiHiHUMSfRcD5cknGOJ8sRPMxjqIUsYrUERwgBfgKCln3updAIoTc37L8UhKz33I5DZBl/wozAMlNFBhimxtKW1Uomifbv38QCv9uk5wxPI4GwMw+70JVm9dVZK6pzm5vD1dA2GkXCG3hBitwfTbkYNJ8FciI6+YTFPGPEhMY2Da9fjEuU+sJ9RXaLr/QA8W2XW19zo33jmlparrBBLtSdzTcs8JAk6OqWaaTPfsOiJ06aCv/mUM4BIlbt1Inbjc+/kaoSImkmD9+Bq3k1Gsn6AuPtjjlNJy7dQjA6RjkO3lQmd69tRu6vN4bqnSx58nyRmmRV8Oe3HLJ4iBhlNJtQ61+lZ/M5o4WyyU+D+g1PAQE9vWtaBGiNbakcp/DtrGyvIeeZJxYsWt5c8upJdOpIyxcf/mPcaaHX3JDNN1pyfMZ5MLXPz6RcXof6Sbao+atRxTKdS/yb/KQ2xDYTyo8UJdb+3ALlxf6wy1c5fSeNyf8zlni3w3BEeojT9scfl/NWY40uLLgjRA3Nb7J7TknbqtaNfmKZ7H2McX5R6MjmZWclh88d9eQTiKRRl2vJedQLu8Y9YaV3XPHNFBKzeyHztG9cUp/gKBrzrg+HLyI7gsd6d31RZhlF/eMnIU9aos2VSzyfW6imPe6ahg7GffReOO16n0mO8jFOkJ9Rzgtip6xmcH13EW/Vwty4qhSDMDs4mAurnOSstDCVcIAhMa17zmSYr7vBD4mQCiLk2y/z/xq9K/+Yp+fFfpfoXHGuyHc57hSAKQCXN5ayjNfx9H5ecniPbMRUmG+Pkafy7LC8jM6hkIITP9nYzqWzY3KYi6bTx346Q2DZdIZqQnz/MKdmrD35lTSgLV68TmUsI8O69WCvn5bJ4afttZgK90aw95ZABufxUET46g5rm+McdOtDpAB28JNvYMTOofULbbcU/EYGgimV1yO03i8EyZMmPAf4R8zPzVpg7OAWQAAAABJRU5ErkJggg==";

  isCollapsed = true;

  toggleCollapse(): void {
    this.isCollapsed = !this.isCollapsed;
  }
}
