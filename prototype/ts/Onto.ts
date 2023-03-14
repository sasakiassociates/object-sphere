import { getSnapshot, model, Model, prop } from 'mobx-keystone';


@model('onto')
class Onto extends Model({}) {

    public readonly isOnto = true;

    public get<T extends { name: string } = any>(klass: T): T[] {
        return Object.keys(this.$).map(name => {
            const member = (this as any)[name];

            if (Array.isArray(member)) {
                if (name === klass.name) {
                    return member;
                }
                else if (member.length > 0 && member[0].isOnto) {
                    return member.map(membee => membee.get(klass)).reduce(_concat, []);
                }
            }
            else {
                if (name === klass.name) {
                    return [member];
                }
                else if (member.isOnto) {
                    return member.get(klass);
                }
            }

            return undefined;
        })
        .filter(a => a !== undefined)
        .reduce(_concat, []);
    }

} 

export default Onto;


/**
 * Serialization
 */

export function serialize<T extends object>(obj: T) {
    const tree = getSnapshot<T>(obj) as { $modelType: string };
    const modelType = tree.$modelType.replace('onto/', '');

    function _serialize(tree: { $modelType?: string }) {
        // Serialize
        delete tree.$modelType;

        // Traverse
        Object.values(tree).forEach((member: any) => {
            if (typeof member !== 'number' && typeof member !== 'string') {
                if (Array.isArray(member)) {
                    member.forEach(_serialize);
                }
                else {
                    _serialize(member);
                }
            }
        });

        return tree;
    }


    return { [modelType]: _serialize(tree) };
}

export function deserialize<T>(klass: T, json: object) {
}


/**
 * Private utils
 */

function _concat(a: any[], b: any[]): any[] {
    return [...a, ...b];
}
