import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'replace'
  })
  export class ReplacePipe implements PipeTransform {

    transform(value: string, repleceText: string = 'Internista', repleceText2: string = 'Gastrolog', repleceText3: string = 'Okulista', repleceText4: string = 'Pulmonolog'): any {
        if (value == '7e69e274-2457-497b-f0a2-08d92a80bcac') 
        {
            return repleceText;
        }
        else if(value == '7973dcfc-a45c-4576-f0a3-08d92a80bcac')
        {
            return repleceText;
        }
        else if(value == 'bd04bdb4-1d19-41a0-30c9-08d92b58d8f6')
        {
            return repleceText2;
        }
        else if(value == '26ad7e5b-e05f-41b3-30ca-08d92b58d8f6')
        {
            return repleceText3;
        }
        else if(value == '5fa7d7af-cce0-44b4-30cb-08d92b58d8f6')
        {
            return repleceText4;
        }
        
      }
  }